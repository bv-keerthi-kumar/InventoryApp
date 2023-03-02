using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.Interfaces
{
    public interface IInventoryRepository : IRepository<Data.Models.Inventory>
    {
        Task<Data.Models.Inventory> GetByProductName(string productName);
        Task<Data.Models.Inventory> GetByHighestQuantity();
        Task<Data.Models.Inventory> GetByLowestQuantity();
        Task<Data.Models.Inventory> GetByOldestItem();
        Task<Data.Models.Inventory> GetByLatestItem();
    }
}
