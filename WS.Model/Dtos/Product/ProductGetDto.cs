using Infrastructure.Model;

namespace WS.Model.Dtos.Product
{
    public class ProductGetDto:IDto
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? CategoryName { get; set; }
    }
}
