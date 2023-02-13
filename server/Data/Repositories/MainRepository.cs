using AutoMapper;
using Data.Entities;
using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MainRepository : IMainRepository
    {
        private readonly BRUContext context;
        private readonly IMapper mapper;

        public MainRepository(BRUContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<InventoryModel>> GetInventory()
        {
            return await mapper.ProjectTo<InventoryModel>(context.Inventory.Include(i => i.Product)).ToListAsync();
        }

        public async Task<bool> PutInventoryProduct(InventoryModel model)
        {
            var existingEntity = await context.Inventory.Where(x => x.Id == model.Id).Include(i => i.Product).FirstOrDefaultAsync();
            var newEntity = mapper.Map<Inventory>(model);

            if (existingEntity != null) // update
            {
                context.Entry(existingEntity.Product).CurrentValues.SetValues(newEntity.Product);
                context.Entry(existingEntity).CurrentValues.SetValues(newEntity);
            }
            else // add
            {
                context.Inventory.Add(newEntity);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteInventoryProduct(long inventoryId)
        {
            var existingEntity = await context.Inventory.Where(x => x.Id == inventoryId).Include(i => i.Product).FirstOrDefaultAsync();

            if (existingEntity != null)
            {
                context.Inventory.Remove(existingEntity);
                context.Product.Remove(existingEntity.Product);
                return await context.SaveChangesAsync() > 0;
            }
            else // not found
            {
                return false;
            }
        }
    }
}
