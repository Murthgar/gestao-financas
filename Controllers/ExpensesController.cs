using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestãoFinancas.Models;
using GestãoFinancas.Data;
using GestãoFinancas.Dtos;
using AutoMapper;

namespace GestãoFinancas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ExpensesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // POST: api/expenses
        [HttpPost]
        [HttpPost]
        public IActionResult Create([FromBody] ExpenseDto dto)
        {
            // Validação do modelo
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verifica se a categoria existe
            var category = _context.Categories.Find(dto.CategoryId);
            if (category == null)
                return BadRequest(new { error = "Categoria inválida." });

            // Validações de recorrência
            if (dto.IsRecurring)
            {
                if (!dto.RecurrenceType.HasValue)
                    return BadRequest(new { error = "Tipo de recorrência é obrigatório quando IsRecurring = true." });

                if (!dto.EndRecurrence.HasValue)
                    return BadRequest(new { error = "EndRecurrence é obrigatório quando IsRecurring = true." });

                if (dto.EndRecurrence.Value.Date <= dto.Date.Date)
                    return BadRequest(new { error = "EndRecurrence deve ser posterior à data inicial." });
            }

            // Mapeamento da despesa
            var expense = _mapper.Map<Expense>(dto);
            expense.Category = category;

            _context.Expenses.Add(expense);
            _context.SaveChanges(); // importante para gerar ID da despesa

            // Capturar recorrências geradas
            List<Expense> recurrences = new();
            if (expense.IsRecurring && expense.RecurrenceType.HasValue && expense.EndRecurrence.HasValue)
            {
                recurrences = GenerateRecurringExpenses(expense); // <- refatorado para retornar lista
                _context.Expenses.AddRange(recurrences);
                _context.SaveChanges();
            }

            // DTO de resposta
            var responseDto = new ExpenseCreateResponseDto
            {
                Expense = _mapper.Map<ExpenseReadDto>(expense),
                GeneratedRecurrences = _mapper.Map<IEnumerable<ExpenseReadDto>>(recurrences)
            };

            // Resposta agora inclui recorrências geradas
            return CreatedAtAction(nameof(GetById), new { id = expense.Id }, responseDto);
        }


        // GET: api/expenses/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var expense = _context.Expenses
                .Include(e => e.Category)
                .FirstOrDefault(e => e.Id == id);

            if (expense == null)
                return NotFound();

            var readDto = _mapper.Map<ExpenseReadDto>(expense);
            return Ok(readDto);
        }

        // GET: api/expenses
        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = _context.Expenses
                .Include(e => e.Category)
                .ToList();

            var readDtos = _mapper.Map<List<ExpenseReadDto>>(expenses);
            return Ok(readDtos);
        }

        // Gera as despesas recorrentes a partir da despesa original já salva
        private List<Expense> GenerateRecurringExpenses(Expense expense)
        {
            var nextDate = expense.Date;
            var safetyCounter = 0; // Evita laços muito longos em casos extremos
            var recurringExpenses = new List<Expense>();

            while (true)
            {
                nextDate = GetNextDate(nextDate, expense.RecurrenceType!.Value);
                if (nextDate > expense.EndRecurrence!.Value)
                    break;

                var recurringExpense = new Expense
                {
                    Description = expense.Description,
                    Amount = expense.Amount,
                    Date = nextDate,
                    IsPaid = false,
                    CategoryId = expense.CategoryId,
                    // Evite setar a navigation para evitar conflitos de tracking
                    IsRecurring = true,
                    RecurrenceType = expense.RecurrenceType,
                    EndRecurrence = expense.EndRecurrence
                };

                recurringExpenses.Add(recurringExpense);

                safetyCounter++;
                if (safetyCounter > 1000) break;
            }

            return recurringExpenses;
        }

        // Calcula a próxima data conforme o tipo de recorrência
        private DateTime GetNextDate(DateTime current, RecurrenceType type)
        {
            return type switch
            {
                RecurrenceType.Daily => current.AddDays(1),
                RecurrenceType.Weekly => current.AddDays(7),
                RecurrenceType.Monthly => current.AddMonths(1),
                RecurrenceType.Yearly => current.AddYears(1),
                _ => current
            };
        }
    }
}