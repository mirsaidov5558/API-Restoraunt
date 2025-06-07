using API_Restoran.DTOs.RoleDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<Role, RoleDto>();
            CreateMap<CreateRoleDto, Role>();
        }
    }
}
