using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GestãoFinancas.Models;

namespace GestãoFinancas.Dtos
{
    public class ExpenseDto
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsPaid { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public bool IsRecurring { get; set; }
        public RecurrenceType? RecurrenceType { get; set; }
        public DateTime? EndRecurrence { get; set; }

    }
}