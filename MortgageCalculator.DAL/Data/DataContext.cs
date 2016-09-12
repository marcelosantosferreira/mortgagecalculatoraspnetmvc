using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MortgageCalculator.Model;

namespace MortgageCalculator.DAL.Data
{
    public class DataContext: DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
