using AutoMapper;
using TMarket.Application.DomainModels;
using TMarket.Persistence.DbModels;
using TMarket.WEB.Commands.CategoryCommands;
using TMarket.WEB.Commands.UserCommands;
using TMarket.WEB.RequestModels;
using TMarket.WEB.RequestModels.Orders;
using TMarket.WEB.RequestModels.Products;

namespace TMarket.WEB.MappingProfiles
{
    public class DtoToRequestProfile : Profile
    {
        public DtoToRequestProfile()
        {
            CreateMap<UserDTO, UserRespond>();
            CreateMap<UserRequestCommand, UserDTO>();

            CreateMap<ProductDTO, ProductRespond>().ForMember(dest => dest.CategoryName, opt 
                => opt.MapFrom(src => src.Category.Name));

            CreateMap<ProductRequest, ProductDTO>();

            CreateMap<OrderProductDTO, ProductOrderResponse>();

            CreateMap<OrderDTO, OrderResponse>();

            CreateMap<OrderRequest, OrderDomain>().ReverseMap();
            
            CreateMap<ProductOrderRequest, OrderProductDomain>();

            CreateMap<CategoryDTO, CategoryRespond>();
            CreateMap<CategoryRequestCommand, CategoryDTO>();
        }
    }
}
