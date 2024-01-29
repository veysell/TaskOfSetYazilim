using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Employee:BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string SurName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(11)")]
        public string InternationalId { get; set; }

        public int EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
    }
}
