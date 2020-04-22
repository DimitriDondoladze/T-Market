using AutoMapper;
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
        }
    }
}
