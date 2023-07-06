using System;
using Volo.Abp.Domain.Entities;

namespace ZURU.Demo.Domain
{
    public class UserRole: Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }

        private UserRole() { }

        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
