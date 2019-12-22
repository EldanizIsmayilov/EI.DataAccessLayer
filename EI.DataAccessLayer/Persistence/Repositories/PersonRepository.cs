using EI.DataAccessLayer.Abstractions.Repositories;
using EI.DataAccessLayer.Entities;
using EI.DataAccessLayer.Persistence.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.DataAccessLayer.Persistence.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
