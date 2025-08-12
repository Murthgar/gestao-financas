using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestãoFinancas.Data;
using GestãoFinancas.Models;

namespace GestãoFinancas.Services
{
    public class ExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseService(AppDbContext context)
        {
            _context = context;
        }

        public List<Expense> GetOverdueExpenses()
        {
            return _context.Expenses
                .Where(e => !e.IsPaid && e.Date < DateTime.Today)
                .ToList();
        }
    }
}