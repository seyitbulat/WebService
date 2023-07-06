namespace WS.Model.Dtos.Product
{
    public class ProductPostDto
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? CategoryName { get; set; }
    }
}
