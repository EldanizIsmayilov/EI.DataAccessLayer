using IEldaniz.DataAccessLayer.Abstractions.Repositories;
using IEldaniz.DataAccessLayer.Entities;
using IEldaniz.DataAccessLayer.Persistence.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.DataAccessLayer.Persistence.Repositories
{
    public class SampleEntityRepository : GenericRepository<SampleEntity>, ISampleEntityRepository
    {
        public SampleEntityRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
