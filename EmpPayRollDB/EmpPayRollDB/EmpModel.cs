using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPayRollDB
{
    public class EmpModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public decimal Salary { get; set; }


        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }


        public string Address { get; set; }
        public decimal Pay { get; set; }
        public decimal Deduction { get; set; }
        public decimal Texable { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetPay { get; set; }
    }
}
