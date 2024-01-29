using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AbstractService<TEntity>:IAbstractService<TEntity> where TEntity:BaseEntity
    {
    }

    public interface IAbstractService<TEntity>:IBusinessService where TEntity : BaseEntity
    {
    }
}
