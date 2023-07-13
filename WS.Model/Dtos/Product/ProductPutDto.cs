﻿using Infrastructure.Model;

namespace WS.Model.Dtos.Product
{
    public class ProductPutDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public int? CategoryId { get; set; }
    }
}
