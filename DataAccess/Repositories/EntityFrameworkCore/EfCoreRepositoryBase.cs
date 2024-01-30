using DataAccess.Entities;
using DataAccess.Models;
using DataAccess.mssql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EfCoreRepositoryBase<TEntity> : IEntityRepositoryService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DataContext _context;
        public EfCoreRepositoryBase(DataContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().Where(filter).ToList();
        }

        public List<SalaryList> GetAllSalaryList()
        {
            var list = _context.SalaryInfos.FromSqlRaw($"EXEC dbo.sp_CalculateAllSalary").AsEnumerable().Select(x=> new SalaryList
            {
                Name = x.Name,
                SurName = x.SurName,
                Salary = x.Salary,
                InternationalId = x.InternationalId
            }).ToList();
            
            return list;
        }

        public SalaryList GetSalaryInfo(int employeeId)
        {
            var item = _context.SalaryInfos.FromSqlRaw($"EXEC dbo.sp_GetSalaryByEmployeeId {employeeId}").AsEnumerable().Select(x => new SalaryList
            {
                Name = x.Name,
                SurName = x.SurName,
                Salary = x.Salary,
                InternationalId = x.InternationalId
            }).First();
            return item;
           
        }

        public IQueryable<TEntity> Include(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(predicate);
        }

        public void Update(TEntity entity)
        {
            var uptadedEntity = _context.Entry(entity);
            uptadedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    public interface IEntityRepositoryService<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
        List<SalaryList> GetAllSalaryList();
        SalaryList GetSalaryInfo(int employeeId);

        IQueryable<T> Include(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    }
}
