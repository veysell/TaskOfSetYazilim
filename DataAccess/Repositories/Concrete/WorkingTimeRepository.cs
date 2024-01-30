using DataAccess.Entities;
using DataAccess.mssql;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class WorkingTimeRepository : EfCoreRepositoryBase<EmployeeWorkingDayOrHour>, IWorkingTimeRepository
    {
        public WorkingTimeRepository(DataContext context) : base(context)
        {
        }
    }
}
