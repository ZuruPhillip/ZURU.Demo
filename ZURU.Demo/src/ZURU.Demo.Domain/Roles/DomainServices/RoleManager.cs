using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ZURU.Demo.Domain
{
    public class RoleManager : DomainService, IRoleManager
    {
        private readonly IRepository<Role> _repository;
        public RoleManager(IRepository<Role> repository)
        {
            _repository= repository;
        }

        public async Task<Role> CreateRoleAsync(string roleName, string desc, bool isDefault)
        {
            var role = await _repository.FindAsync(p=>p.Name==roleName);
            if (role != null)
                return role;

            role = new Role(roleName,desc, isDefault);
            return await _repository.InsertAsync(role);
        }

        public Task<Role> AssignPermissionsAsync(Role role, List<Guid> permissionIds)
        {
            foreach (var permissionId in permissionIds)
            {
                role.AddPermission(permissionId);
            }

            return Task.FromResult<Role>(role);
        }

        public async Task<List<Role>> GetDefaultRolesAsync()
        {
            return await _repository.GetListAsync(p=>p.IsDefault);
        }
    }
}
