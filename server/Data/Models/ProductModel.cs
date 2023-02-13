namespace Data.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
        public decimal Price { get; set; }
        public long ProductTypeId { get; set; }
        public long? BikeTypeId { get; set; }
        public long BrandId { get; set; }
        public long? ImageId { get; set; }
        public ReferenceDataModel BikeType { get; set; }
        public ReferenceDataModel Brand { get; set; }
        public ReferenceDataModel ProductType { get; set; }
    }
}
