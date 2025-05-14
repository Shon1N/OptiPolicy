using AutoMapper;
using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Entities;

namespace OptiPolicy.Api.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<GroupDto, Group>().ReverseMap();
            CreateMap<GroupPermissionDto, GroupPermission>().ReverseMap();
            CreateMap<PermissionDto, Permission>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserGroupDto, UserGroup>().ReverseMap();
        }
    }
}