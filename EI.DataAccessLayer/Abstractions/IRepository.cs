using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EI.DataAccessLayer.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAsQueryable();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
       
        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Attach(TEntity entity);

        void AttachRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        void DeleteRange(IEnumerable<TEntity> entities);

        bool CheckExist(Expression<Func<TEntity, bool>> predicate);

    }
}
