using AutoMapper;
using System.Linq;
using ZURU.Demo.Domain;

namespace ZURU.Demo.Application;

public class DemoApplicationAutoMapperProfile : Profile
{
    public DemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Role, RoleDto>()
            .ForMember(
            dest=>dest.PermissionIds,
            opt=>opt.MapFrom(s=>s.PermissionGrants.Select(p=>p.PermissionId))
            );

        CreateMap<Permission, PermissionDto>();
    }
}
