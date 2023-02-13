using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMainRepository mainRepo;

        public InventoryController(IMainRepository mainRepo) 
        {
            this.mainRepo = mainRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mainRepo.GetInventory());
        }

        [HttpPut]
        public async Task<IActionResult> Put(InventoryModel model)
        {
            return Ok(await mainRepo.PutInventoryProduct(model));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await mainRepo.DeleteInventoryProduct(id));
        }
    }
}
