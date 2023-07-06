using System;
using System.Collections.Generic;

namespace ZURU.Demo.Application
{
    public class CreateRoleDto
    {
        /// <summary>
        /// 是否是默认角色
        /// </summary>
        public bool IsDefault { get; set; }

        public string RoleName { get; set; }

        public string Desc { get; set; }

        /// <summary>
        /// 角色拥有的权限Code
        /// </summary>
        public List<Guid> PermissionCodes { get; set; }
    }
}
