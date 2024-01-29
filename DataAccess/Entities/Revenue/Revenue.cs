using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Revenue:BaseEntity
    {
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal FixedSalaryAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal OvertimeAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal DailyAmount { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }
    }
}
