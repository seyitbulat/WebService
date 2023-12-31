﻿using Infrastructure.Model;
using WS.Model.Dtos.Product;

namespace WS.Model.Dtos.Category
{
    public class CategoryGetDto:IDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        public List<ProductGetDto>? Products { get; set; }
    }
}
