using AutoMapper;
using dotnet1.Dto;
using dotnet1.Entity;

namespace dotnet1.Mappings.Profiles;
using AutoMapper;
using dotnet1.Entity;
using dotnet1.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<Category, CategoryDto>();
        CreateMap<Product, ProductDto>();

        CreateMap<Order, OrderDto>();

        CreateMap<Customer, CustomerDto>();
        CreateMap<OrderDetail, OrderDetailDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : "Unknown"));
    }
}
