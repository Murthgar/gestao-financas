using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestãoFinancas.Models
{
    public class FinancialDashboard
    {
        public decimal TotalExpenses { get; set; }
        public decimal PaidExpenses { get; set; }
        public decimal PendingExpenses { get; set; }
        public decimal OverdueExpenses { get; set; }
        public decimal CurrentMonthExpenses { get; set; }
        public List<CategorySummary> CategoryBreakdown { get; set; } = new();
    }

}