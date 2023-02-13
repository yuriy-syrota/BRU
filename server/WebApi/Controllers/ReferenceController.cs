using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceRepository repo;
        public ReferenceController(IReferenceRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("ProductTypes")]
        public async Task<IActionResult> GetProductTypes()
        {
            return Ok(await repo.GetProductTypes());
        }

        [HttpGet("BikeTypes")]
        public async Task<IActionResult> GetBikeTypes()
        {
            return Ok(await repo.GetBikeTypes());
        }

        [HttpGet("Brands")]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await repo.GetBrands());
        }

    }
}
