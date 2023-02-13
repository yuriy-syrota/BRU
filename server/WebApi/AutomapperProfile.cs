using AutoMapper;
using Data.Entities;
using Data.Models;

namespace WebApi
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() : this("Default")
        {
        }

        public AutomapperProfile(string profileName) : base(profileName)
        {
            CreateMap<Inventory, InventoryModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductType, ReferenceDataModel>().ReverseMap();
            CreateMap<BikeType, ReferenceDataModel>().ReverseMap();
            CreateMap<Brand, ReferenceDataModel>().ReverseMap();
        }
    }
}
