using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestãoFinancas.Dtos
{
    public class ExpenseCreateResponseDto
    {
        public ExpenseReadDto Expense { get; set; }
        public IEnumerable<ExpenseReadDto> GeneratedRecurrences { get; set; }

    }
}