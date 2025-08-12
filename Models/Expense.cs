using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestãoFinancas.Models
{
    public class Expense
    {
        public int Id { get; set; }                      // Identificador único da despesa
        public string Description { get; set; }          // Descrição da despesa (ex: "Conta de luz")
        public decimal Amount { get; set; }              // Valor da despesa
        public DateTime Date { get; set; }               // Data da despesa ou vencimento
        public bool IsPaid { get; set; }                 // Indica se a despesa já foi paga

        // Regra de negócio: verifica se a despesa está vencida
        public bool IsOverdue()
        {
            return !IsPaid && Date < DateTime.Today;
        }
        public int CategoryId { get; set; } // Foreign key for Category
        public Category Category { get; set; } // Navigation property for Category

    }
}