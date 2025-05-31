using API_Restoran.DTOs.IngredientDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile() 
        {
            CreateMap<Ingredient, IngredientDto>();            // на чтение
            CreateMap<CreateIngredientDto, Ingredient>();
        }
    }
}
