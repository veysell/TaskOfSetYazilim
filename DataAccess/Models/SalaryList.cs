using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class SalaryList
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string InternationalId { get; set; }
        public decimal Salary { get; set; }
    }
}
