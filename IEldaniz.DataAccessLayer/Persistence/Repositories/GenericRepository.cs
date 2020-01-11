using IEldaniz.DataAccessLayer.Abstractions;
using IEldaniz.DataAccessLayer.Persistence.DBContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.DataAccessLayer.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private DbSet<TEntity> _dbset;
        protected readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbset = _appDbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbset.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }

        public void Attach(TEntity entity)
        {
            _dbset.Attach(entity);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Attach(entity);
        }

        public bool CheckExist(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll(predicate))
                Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbset.OrderBy(x => x.Id).ToList();

            return _dbset.Where(predicate).OrderBy(x => x.Id).ToList();
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
            return _dbset;
        }


    }
}
