using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using ZURU.Demo.Domain;

namespace ZURU.Demo.Application
{
    public class RoleAppService : DemoAppService, IRoleAppService
    {
        private readonly IRoleManager _roleManager;
        private readonly IRoleRepository _roleRepository;//自定义仓储
        private readonly IRepository<Role> _repository; //通用仓储
        public RoleAppService(
            IRoleManager roleManager,
            IRoleRepository roleRepository,
            IRepository<Role> repository
            )
        {
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _repository = repository;
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            var role = await _roleManager.CreateRoleAsync(dto.RoleName, dto.Desc,dto.IsDefault);

            //处理分配的权限
            if (dto.PermissionCodes != null)
                await _roleManager.AssignPermissionsAsync(role, dto.PermissionCodes);

            return ObjectMapper.Map<Role, RoleDto>(role);
        }

        public async Task<RoleDto> FindByNameHasDetailsAsync(string roleName)
        {
            /*
             * 自定义仓储会返回聚合根的实体
             */

            var role = await _roleRepository.FindAsync(p => p.Name == roleName);

            return ObjectMapper.Map<Role, RoleDto>(role);
        }

        public async Task<RoleDto> FindByNameNoDetailsAsync(string roleName)
        {
            /*
             * 通用仓储默认查不出聚合根的实体，除非配置了 AbpEntityOptions.DefaultWithDetailsFunc
             */

            var role = await _repository.FindAsync(p => p.Name == roleName);

            return ObjectMapper.Map<Role, RoleDto>(role);
        }
    }
}
