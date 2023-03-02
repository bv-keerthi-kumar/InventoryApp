using Inventory.Repositories.Interfaces;
using Inventory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories
{
    public class InventoryRepository : GenericRepository<Data.Models.Inventory> , IInventoryRepository
    {
        private readonly InventoryDBContext _dbContext;

        public InventoryRepository(InventoryDBContext context): base(context)
        {
            _dbContext = context;
        }

        public async Task<Data.Models.Inventory> GetByHighestQuantity()
        {
          return await _dbContext.Inventories.Where(y => y.Quantity == _dbContext.Inventories.Max(x => x.Quantity)).FirstOrDefaultAsync();           
        }       

        public async Task<Data.Models.Inventory> GetByLowestQuantity()
        {
            return await _dbContext.Inventories.Where(y => y.Quantity == _dbContext.Inventories.Min(x => x.Quantity)).FirstOrDefaultAsync();
        }

        public async Task<Data.Models.Inventory> GetByLatestItem()
        {
          return await  _dbContext.Inventories.OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync();
        }

        public async Task<Data.Models.Inventory> GetByOldestItem()
        {
            return await _dbContext.Inventories.OrderBy(x => x.CreatedOn).FirstOrDefaultAsync();
        }

        public async Task<Data.Models.Inventory> GetByProductName(string productName)
        {
            return  await _dbContext.Inventories.Where(a => a.ProductName == productName).FirstOrDefaultAsync();
        }
    }
}
