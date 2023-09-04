using AutoMapper;
using Digital.Data.Models;
using Digital.Dto;

namespace Digital.Web.MappingProfile
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductViewDto, Products>().ReverseMap();
            
        }
    }
}
