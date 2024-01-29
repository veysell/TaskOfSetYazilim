using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class EmployeeWorkingDayOrHour:BaseEntity
    {
        [Column(TypeName ="decimal(4,1)")]
        public decimal WorkingDayOrHour { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
