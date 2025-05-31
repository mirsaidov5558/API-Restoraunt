using API_Restoran.DTOs.OrderDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            // Order -> OrderDto
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.TableId, opt => opt.MapFrom(src => src.TableId ?? 0))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId ?? 0));

            // CreateOrderDto -> Order
            CreateMap<CreateOrderDto, Order>();

            // UpdateOrderDto -> Order (если потребуется)
            CreateMap<UpdateOrderDto, Order>();
        }
    }
}
