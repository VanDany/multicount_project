using AutoMapper;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;

namespace multicount_WEB.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TransactionDTO, TransactionCreateDTO>().ReverseMap();
            CreateMap<TransactionDTO, TransactionUpdateDTO>().ReverseMap();

            CreateMap<CategoryDTO, CategoryCreateDTO>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateDTO>().ReverseMap();
        }
    }
}
