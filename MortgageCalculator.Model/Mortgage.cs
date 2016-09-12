using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Model
{
    public class Mortgage
    {
        public int mortgageId { get;set; }
        public decimal amount { get; set; }
        public decimal interest { get; set; }
        public int period { get; set; }
        public DateTime insertedIn { get; set; }
        public string email { get; set; }
        public bool sent { get; set; }
        public decimal monthlypayment { get; set; }
    }
}
