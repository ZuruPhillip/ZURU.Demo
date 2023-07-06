using System;
using System.Linq;
using Volo.Abp;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ZURU.Demo.Domain
{
    public class User: FullAuditedAggregateRoot<Guid>
    {
        #region 属性
        public string UserName { get; private set; }

        public string Password { get; private set; }

        public UserProfile Profile { get; private set; }

        public ICollection<UserRole> Roles { get; private set; }
        #endregion

        private User() { }

        public User(string userName, string password, UserProfile profile)
        {
            Check.NotNullOrWhiteSpace(userName, nameof(userName));
            Check.NotNullOrWhiteSpace(password, nameof(password));

            UserName = userName;
            Password = password;

            SetProfile(profile);

            CreationTime = DateTime.UtcNow;

            //添加领域事件
            //注意：此时不会立刻发布事件，当数据持久化的工作单元被提交时才会发布。
            //如果事件Handler出错工作单元会被回滚
            AddLocalEvent(new UserAddedDomainEvent()
            {
                User = this,
                CreationTime = this.CreationTime
            });
        }

        #region 方法
        public void SetProfile(UserProfile profile)
        {
            if (string.IsNullOrWhiteSpace(profile.Mobile) &&
                string.IsNullOrWhiteSpace(profile.Email) &&
                string.IsNullOrWhiteSpace(profile.Address)
                )
            {
                throw new Exception("The parameters cannot all be empty:[mobile,email,address]");   
            }

            Profile = profile;
        }

        public void AddRole(Guid roleId)
        {
            if(Roles==null)
                Roles=new List<UserRole>();

            if (Roles.Any(p => p.RoleId == roleId))
                return;

            Roles.Add(new UserRole(this.Id, roleId));
        }
        #endregion
    }
}
