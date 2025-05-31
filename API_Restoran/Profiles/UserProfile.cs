using API_Restoran.DTOs.UserDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()           // конструктор
        {
            // User → UserDto
            CreateMap<User, UserDto>()             // исход → целевой
                .ForMember(dest => dest.Role,       // маппим строку Role
                           opt => opt.MapFrom(src => src.Role.Name));

            // CreateUserDto → User (используется опционально)
            CreateMap<CreateUserDto, User>();      // простое соответствие
        }
    }
}
