using Infrastructure.Model;

namespace WS.Model.Entities
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }

        // Relational table keys
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }

        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? QuantityPerUnit { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //Navigation Property
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
