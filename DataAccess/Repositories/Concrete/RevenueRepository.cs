using DataAccess.Entities;
using DataAccess.mssql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RevenueRepository : EfCoreRepositoryBase<Revenue>, IRevenueRepository
    {
        public RevenueRepository(DataContext context) : base(context)
        {
        }
    }
}
