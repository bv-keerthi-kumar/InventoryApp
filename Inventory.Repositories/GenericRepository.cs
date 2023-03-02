using Inventory.Repositories.Interfaces;
using System;
using Inventory.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public GenericRepository(InventoryDBContext context)
        {
            _dbSet = context.Set<T>();
        }
        
        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> ReadAll()
        {
            return await _dbSet.ToListAsync();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }


    }
}
