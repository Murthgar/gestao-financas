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
        public IActionResult Create([FromBody] ExpenseDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = _context.Categories.Find(dto.CategoryId);
            if (category == null)
                return BadRequest("Categoria inválida.");

            var expense = _mapper.Map<Expense>(dto);
            expense.Category = category;

            _context.Expenses.Add(expense);
            _context.SaveChanges();

            var readDto = _mapper.Map<ExpenseReadDto>(expense);
            return CreatedAtAction(nameof(GetById), new { id = expense.Id }, readDto);
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
    }
}