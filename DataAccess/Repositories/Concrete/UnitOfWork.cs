using DataAccess.mssql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context=context;
            Employee = new EmployeeRepository(_context);
            EmployeeType = new EmployeeTypeRepository(_context);
            Revenue = new RevenueRepository(_context);
        }
        public IEmployeeRepository Employee {get;private set;}

        public IEmployeeTypeRepository EmployeeType{get;private set;}

        public IRevenueRepository Revenue { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
