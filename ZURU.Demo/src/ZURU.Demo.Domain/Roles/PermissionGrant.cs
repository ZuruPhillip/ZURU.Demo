using System;
using Volo.Abp.Domain.Entities;

namespace ZURU.Demo.Domain
{
    /// <summary>
    /// 角色拥有的权限
    /// </summary>
    public class PermissionGrant:Entity<Guid>
    {
        public Guid RoleId { get; private set; }
        public Guid PermissionId { get; private set; }

        private PermissionGrant() { }

        public PermissionGrant(Guid roleId,Guid permissionId)
        { 
            RoleId = roleId;
            PermissionId = permissionId;
        }
    }
}
