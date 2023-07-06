using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ZURU.Demo.Domain
{
    public class Role: FullAuditedAggregateRoot<Guid>
    {
        #region 属性
        /// <summary>
        /// 是否是默认角色
        /// </summary>
        public bool IsDefault { get; private set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 角色描述
        /// </summary>

        public string Desc { get; private set; }

        public ICollection<PermissionGrant> PermissionGrants { get; private set; }
        #endregion

        private Role() { }

        public Role(string roleName,string desc, bool isDefault=false)
        {
            Check.NotNullOrWhiteSpace(roleName, nameof(roleName));

            Name = roleName;
            Desc = desc;
            IsDefault = isDefault;

            CreationTime = DateTime.UtcNow;
        }

        #region 方法
        /// <summary>
        /// 给角色添加权限
        /// </summary>
        /// <param name="permissionCode">权限编码</param>
        public void AddPermission(Guid permissionCode) 
        {
            if(PermissionGrants == null)
                PermissionGrants = new List<PermissionGrant>();

            if (!PermissionGrants.Any(p => p.PermissionId == permissionCode))
                PermissionGrants.Add(new PermissionGrant(this.Id, permissionCode));
        }

        
        #endregion
    }
}
