using AutoMapper;
using Multicount_WEB.Models.Dto;

namespace multicount_WEB.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TransactionDTO, TransactionCreateDTO>().ReverseMap();
            CreateMap<TransactionDTO, TransactionUpdateDTO>().ReverseMap();

            CreateMap<CategoryDTO, LocalUserCreateDTO>().ReverseMap();
            CreateMap<CategoryDTO, CategoryUpdateDTO>().ReverseMap();
            CreateMap<GroupDTO, GroupUpdateDTO>().ReverseMap();
            CreateMap<GroupDTO, GroupCreateDTO>().ReverseMap();

        }
    }
}
