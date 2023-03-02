using Inventory.Repositories.Interfaces;
using System;
using Inventory.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        public readonly InventoryDBContext _dbContext;
        public IRepository<T> Repository { get; private set; }

        public UnitOfWork(InventoryDBContext context)
        {
            _dbContext = context;
            Repository = new GenericRepository<T>(_dbContext);
        }
        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
