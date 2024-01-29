using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        IEmployeeRepository Employee { get; }
        IEmployeeTypeRepository EmployeeType { get; }
        IRevenueRepository Revenue { get; }
        int SaveChanges();
    }
}
