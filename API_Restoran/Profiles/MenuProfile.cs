using API_Restoran.DTOs.MenuDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile() 
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<CreateMenuDto, Menu>();
        }
    }
}
