using Infrastructure.Model;

namespace WS.Model.Entities
{
    public class OrderDetail : IEntity
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
        public float? Discount { get; set; }

        public Product? Product { get; set; }
    }
}
