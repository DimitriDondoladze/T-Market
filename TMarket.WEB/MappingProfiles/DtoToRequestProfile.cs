using AutoMapper;
using TMarket.Application.DomainModels;
using TMarket.Persistence.DbModels;
using TMarket.WEB.Commands;
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

            CreateMap<ProductDTO, ProductRespond>();
            CreateMap<ProductRequest, ProductDTO>();

            CreateMap<OrderProductDTO, ProductOrderResponse>();

            CreateMap<OrderDTO, OrderResponse>();

            CreateMap<OrderRequest, OrderDomain>().ReverseMap();
            
            CreateMap<ProductOrderRequest, OrderProductDomain>();
        }
    }
}
