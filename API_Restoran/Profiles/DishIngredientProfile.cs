using API_Restoran.DTOs.DishIngredientDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class DishIngredientProfile : Profile
    {
        public DishIngredientProfile() 
        {
            CreateMap<DishIngredient, DishIngredientDto>();
            CreateMap<CreateDishIngredientDto, DishIngredient>();
        }
    }
}
