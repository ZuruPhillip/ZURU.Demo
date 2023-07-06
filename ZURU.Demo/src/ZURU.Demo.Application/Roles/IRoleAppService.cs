using System.Threading.Tasks;
namespace ZURU.Demo.Application
{
    /// <summary>
    /// 角色
    /// </summary>
    public interface IRoleAppService
    {
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<RoleDto> CreateAsync(CreateRoleDto dto);

        /// <summary>
        /// 按角色名称查角色。会返回角色的权限
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<RoleDto> FindByNameNoDetailsAsync(string roleName);

        /// <summary>
        /// 按角色名称查角色。不会返回角色的权限
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<RoleDto> FindByNameHasDetailsAsync(string roleName);
    }
}
