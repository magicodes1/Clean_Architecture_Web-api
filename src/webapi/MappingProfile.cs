using AutoMapper;
using Delicious.core;

namespace Delicious.webapi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO,Product>().ReverseMap();
            CreateMap<CategoryDTO,Category>().ReverseMap();
        }
    }
}