using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestãoFinancas.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Navigation property for related expenses
        public ICollection<Expense>? Expenses { get; set; }
    }
}