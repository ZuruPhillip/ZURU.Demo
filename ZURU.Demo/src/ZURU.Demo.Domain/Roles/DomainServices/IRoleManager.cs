using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZURU.Demo.Domain
{
    public interface IRoleManager
    {
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="desc"></param>
        /// <param name="isDefault">是否是默认角色</param>
        /// <returns></returns>
        Task<Role> CreateRoleAsync(string roleName, string desc,bool isDefault);

        /// <summary>
        /// 给角色赋权限
        /// </summary>
        /// <param name="role"></param>
        /// <param name="permissionIds"></param>
        /// <returns>指派角色后的Role</returns>
        Task<Role> AssignPermissionsAsync(Role role, List<Guid> permissionIds);

        /// <summary>
        /// 获取默认角色
        /// </summary>
        /// <returns></returns>
        Task<List<Role>> GetDefaultRolesAsync();
    }
}
