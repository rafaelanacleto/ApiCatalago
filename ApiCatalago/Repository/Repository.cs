using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiCatalago.Context;
using ApiCatalago.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            //_dbContext.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            //_dbContext.SaveChanges();
            return entity;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
            //_dbContext.SaveChanges();
            return entity;
        }
    }
}