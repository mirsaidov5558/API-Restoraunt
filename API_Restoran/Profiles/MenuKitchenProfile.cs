using API_Restoran.DTOs.MenuKitchenDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class MenuKitchenProfile : Profile
    {
        public MenuKitchenProfile() 
        {
            CreateMap<MenuKitchen, MenuKitchenDto>();
            CreateMap<CreateMenuKitchenDto, MenuKitchen>();
        }
    }
}
