using AutoMapper;
using TMarket.Application.DomainModels;
using TMarket.Persistence.DbModels;
using TMarket.WEB.RequestModels;
using TMarket.WEB.RequestModels.Orders;

namespace TMarket.WEB.MappingProfiles
{
    public class DtoToRequestProfile : Profile
    {
        public DtoToRequestProfile()
        {
            CreateMap<UserDTO, User>()
                .ReverseMap();

            CreateMap<ProductDTO, Product>()
                .ReverseMap();

            CreateMap<OrderProductDTO, ProductOrderResponse>();

            CreateMap<OrderDTO, OrderResponse>();

            CreateMap<OrderRequest, OrderDomain>().ReverseMap();
            
            CreateMap<ProductOrderRequest, OrderProductDomain>();
        }
    }
}
