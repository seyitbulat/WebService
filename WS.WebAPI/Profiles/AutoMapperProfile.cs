using AutoMapper;
using WS.Model.Dtos.Category;
using WS.Model.Dtos.Customer;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Product;
using WS.Model.Dtos.Shipper;
using WS.Model.Dtos.Supplier;
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
                           opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.CompanyName,
                            opt => opt.MapFrom(src => src.Supplier.CompanyName))
                .ForMember(dest => dest.ContactName,
                            opt => opt.MapFrom(src => src.Supplier.ContactName))
                .ForMember(dest => dest.Phone,
                            opt => opt.MapFrom(src => src.Supplier.Phone));

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

            // Supplier Entity
            CreateMap<Supplier, SupplierGetDto>();
            CreateMap<SupplierPostDto, Supplier>();

            // Shipper Entity
            CreateMap<Shipper, ShipperGetDto>();
            CreateMap<ShipperPostDto, Shipper>();
        }
    }
}
