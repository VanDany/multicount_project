using AutoMapper;
using multicount_API.Models;
using multicount_API.Models.Dto;

namespace multicount_API.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TransactionsUsers, TransactionsUsersDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.LocalUser, opt => opt.Ignore());

            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<Transaction, TransactionCreateDTO>().ReverseMap();
            CreateMap<Transaction, TransactionUpdateDTO>().ReverseMap();

            CreateMap<TransactionsUsers, TransactionsUsersCreateDTO>().ReverseMap();

            CreateMap<LocalUser, LocalUserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Group, GroupDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Group, GroupCreateDTO>().ReverseMap();
            CreateMap<Group, GroupUpdateDTO>().ReverseMap();

            CreateMap<GroupsUsers, GroupsUsersDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<LocalUser, LocalUserCreateDTO>().ReverseMap();
            CreateMap<LocalUser, LocalUserUpdateDTO>().ReverseMap();

        }
    }
}
