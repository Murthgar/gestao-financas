using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestãoFinancas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestãoFinancas.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    }

}