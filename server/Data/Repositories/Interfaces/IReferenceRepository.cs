using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IReferenceRepository
    {
        Task<IEnumerable<ReferenceDataModel>> GetBikeTypes();
        Task<IEnumerable<ReferenceDataModel>> GetBrands();
        Task<IEnumerable<ReferenceDataModel>> GetProductTypes();
    }
}