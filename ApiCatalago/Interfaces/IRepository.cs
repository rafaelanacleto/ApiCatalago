using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiCatalago.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate); // _repo.Get(c => c.Id == CategoriaId);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}