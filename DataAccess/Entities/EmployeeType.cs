using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class EmployeeType : BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
