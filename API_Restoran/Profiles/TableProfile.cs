using API_Restoran.DTOs.TableDTOs;
using API_Restoran.Entites;
using AutoMapper;

namespace API_Restoran.Profiles
{
    public class TableProfile : Profile
    {
        public TableProfile() 
        {
            CreateMap<Table, TableDto>();
            CreateMap<CreateTableDto, Table>();
        }
    }
}
