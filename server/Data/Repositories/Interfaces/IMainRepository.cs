using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IMainRepository
    {
        Task<IEnumerable<InventoryModel>> GetInventory();
        Task<bool> PutInventoryProduct(InventoryModel model);
        Task<bool> DeleteInventoryProduct(long inventoryId);
    }
}