using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Repositories;
using Inventory.Repositories.Interfaces;
using Inventory.Services.Interfaces;

namespace Inventory.Services
{
    public class InventoryService :  IInventoryService
    {
        private readonly IUnitOfWork<Data.Models.Inventory> _uow;
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository, IUnitOfWork<Data.Models.Inventory> unitOfWork)
        {
            _inventoryRepository = inventoryRepository;
            _uow = unitOfWork;
        }

        public async Task<Data.Models.Inventory> GetById(int id)
        {
            var result = await _uow.Repository.GetById(id).ConfigureAwait(false);
            return result;
        }

        public async Task<IList<Data.Models.Inventory>> ReadAll()
        {
            var result = await _uow.Repository.ReadAll().ConfigureAwait(false);
            return result;
        }

        public async Task<Data.Models.Inventory> Add(Data.Models.Inventory inventory)
        {
            _uow.Repository.Add(inventory);
            await _uow.Commit().ConfigureAwait(false);
            return inventory;
        }

        public async Task<Data.Models.Inventory> Update(Data.Models.Inventory inventory)
        {
            _uow.Repository.Update(inventory);
            await _uow.Commit().ConfigureAwait(false);
            return inventory;
        }

        public async Task<Data.Models.Inventory> Delete(Data.Models.Inventory inventory)
        {
            _uow.Repository.Delete(inventory);
            await _uow.Commit().ConfigureAwait(false);
            return inventory;
        }

        public async Task<Data.Models.Inventory> GetByProductName(string productName)
        {
            var result = await _inventoryRepository.GetByProductName(productName).ConfigureAwait(false);          
            return result;
        }
    }
}
