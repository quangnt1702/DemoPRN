using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPE.DataTier.Repositories
{
     interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        List<T> Get();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
