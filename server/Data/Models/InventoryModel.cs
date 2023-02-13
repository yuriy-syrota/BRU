namespace Data.Models
{
    public class InventoryModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int? Quantity { get; set; }

        public ProductModel Product { get; set; }
    }
}
