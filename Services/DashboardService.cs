using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestãoFinancas.Data;
using GestãoFinancas.Models;

namespace GestãoFinancas.Services
{
    public class DashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
        }

        public FinancialDashboard GetDashboard()
        {
            var today = DateTime.Today;
            var currentMonth = today.Month;
            var currentYear = today.Year;

            var expenses = _context.Expenses.ToList();

            return new FinancialDashboard
            {
                TotalExpenses = expenses.Sum(e => e.Amount),
                PaidExpenses = expenses.Where(e => e.IsPaid).Sum(e => e.Amount),
                PendingExpenses = expenses.Where(e => !e.IsPaid).Sum(e => e.Amount),
                OverdueExpenses = expenses.Where(e => !e.IsPaid && e.Date < today).Sum(e => e.Amount),
                CurrentMonthExpenses = expenses
                    .Where(e => e.Date.Month == currentMonth && e.Date.Year == currentYear)
                    .Sum(e => e.Amount),
                CategoryBreakdown = expenses
                    .GroupBy(e => e.Category)
                    .Select(g => new CategorySummary
                    {
                        Category = g.Key?.Name ?? "Sem categoria",
                        Total = g.Sum(e => e.Amount)
                    }).ToList()
            };
        }
    }

}