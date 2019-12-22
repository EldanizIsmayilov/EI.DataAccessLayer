using EI.DataAccessLayer.Abstractions;
using EI.DataAccessLayer.Abstractions.Repositories;
using EI.DataAccessLayer.Persistence.DBContexts;
using EI.DataAccessLayer.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EI.DataAccessLayer.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;
        private readonly Dictionary<Type, object> _repositories;
        private bool _isDisposed = false;

        public UnitOfWork()
        {
            _appDbContext = new AppDbContext();
            _repositories = new Dictionary<Type, object>();
         
        }

        public IPersonRepository PersonRepository => GetRepository<IPersonRepository>();

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)) == true)
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;

            var repo = new GenericRepository<TEntity>(_appDbContext);

            _repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _appDbContext.Dispose();
                _isDisposed = true;
            }
        }

        private TRepository GetRepository<TRepository>()
        {
            if (_repositories.Keys.Contains(typeof(TRepository)))
                return (TRepository)_repositories[typeof(TRepository)];

            var type = Assembly.GetExecutingAssembly().GetTypes()
               .FirstOrDefault(x => !x.IsAbstract
               && !x.IsInterface
               && x.Name == typeof(TRepository).Name.Substring(1));

            if (type == null)
                throw new Exception("Repository type is not found");

            var repository = (TRepository)Activator.CreateInstance(type, _appDbContext);

            _repositories.Add(typeof(TRepository), repository);

            return repository;
        }
    }
}
