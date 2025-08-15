using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestãoFinancas.Models
{
    public class ExpenseCsv
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public string CategoryName { get; set; }
        public bool IsRecurring { get; set; }
        public RecurrenceType? RecurrenceType { get; set; }
        public DateTime? EndRecurrence { get; set; }
    }

}