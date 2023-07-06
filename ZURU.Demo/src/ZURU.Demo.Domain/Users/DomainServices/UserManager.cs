using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ZURU.Demo.Domain
{
    public class UserManager : DomainService, IUserManager
    {
        private readonly IRepository<User> _repository;
        private readonly IRoleManager _roleManager;
        public UserManager(IRepository<User> repository, IRoleManager roleManager)
        {
            _repository = repository;
            _roleManager = roleManager;
        }

        public async Task<User> CreateUserAsync(string userName, string password, UserProfile profile)
        {
            var user = await _repository.FindAsync(p=>p.UserName==userName);
            if (user != null)
                return user;

            user=new User(userName, password, profile);

            return await _repository.InsertAsync(user);

            //user=await _repository.InsertAsync(user);

            ////指定默认角色
            //await AssignDefaultRolesAsync(user);

            //return user;
        }

        public async Task AssignDefaultRolesAsync(User user)
        {
            var roles = await _roleManager.GetDefaultRolesAsync();
            if (roles == null || !roles.Any())
                throw new Exception("default role not found");

            roles.ForEach(role => {
                user.AddRole(role.Id);
            });
            
            await _repository.UpdateAsync(user);
        }
    }
}
