using EI.DataAccessLayer.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.DataAccessLayer.Abstractions
{
    public interface IUnitOfWork
    {
        ISampleEntityRepository SampleEntityRepository { get; }

        void SaveChanges();
    }
}
