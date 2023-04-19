using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formular_one_api.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All(int id);
        Task<T?> GetById();
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}