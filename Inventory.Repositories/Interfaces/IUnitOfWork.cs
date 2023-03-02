using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Repositories.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T: class
    {
        public IRepository<T> Repository { get; }

        Task Commit();
    }
}
