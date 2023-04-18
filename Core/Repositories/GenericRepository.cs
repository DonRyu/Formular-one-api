using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formular_one_api.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}