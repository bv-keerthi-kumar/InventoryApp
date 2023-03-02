using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Data.Models;

namespace Inventory.Services.Interfaces
{
    public interface IInventoryService : IGenericService<Data.Models.Inventory>
    {
        Task<Data.Models.Inventory> GetByProductName(string productName);
    }
}
