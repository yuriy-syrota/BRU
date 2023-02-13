using AutoMapper;
using Data.Entities;
using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReferenceRepository : IReferenceRepository
    {
        private readonly BRUContext context;
        private readonly IMapper mapper;

        public ReferenceRepository(BRUContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ReferenceDataModel>> GetProductTypes()
        {
            return await mapper.ProjectTo<ReferenceDataModel>(context.ProductType).ToListAsync();
        }

        public async Task<IEnumerable<ReferenceDataModel>> GetBikeTypes()
        {
            return await mapper.ProjectTo<ReferenceDataModel>(context.BikeType).ToListAsync();
        }

        public async Task<IEnumerable<ReferenceDataModel>> GetBrands()
        {
            return await mapper.ProjectTo<ReferenceDataModel>(context.Brand).ToListAsync();
        }
    }
}
