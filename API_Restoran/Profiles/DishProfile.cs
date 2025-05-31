using API_Restoran.DTOs.DishDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile() 
        {
            CreateMap<Dish, DishDto>();

            // Маппинг из CreateDishDto в Dish (для создания блюда)
            CreateMap<CreateDishDto, Dish>();

            // Маппинг из UpdateDishDto в Dish (для обновления блюда)
            CreateMap<UpdateDishDto, Dish>();
        }
    }
}
