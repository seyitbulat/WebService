using AutoMapper;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Customer;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.WebAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // Product Entity
            CreateMap<Product, ProductGetDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<ProductPostDto, Product>();

            // Category Entity
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryPostDto, Category>();

            // Customer Entity
            CreateMap<Customer, CustomerGetDto>();
            CreateMap<CustomerPostDto, Customer>();

            // Employee Entity
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeePostDto, Employee>();
        }
    }
}
