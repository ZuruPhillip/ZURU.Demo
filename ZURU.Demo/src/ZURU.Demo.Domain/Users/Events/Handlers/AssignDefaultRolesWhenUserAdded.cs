using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace ZURU.Demo.Domain
{
    /// <summary>
    /// 领域事件[UserAddedDomainEvent]的处理程序--用户被创建后给该用户指定默认角色
    /// </summary>
    public class AssignDefaultRolesWhenUserAdded : 
        ILocalEventHandler<UserAddedDomainEvent>, 
        ITransientDependency
    {
        private readonly IUserManager _userManager;
        public AssignDefaultRolesWhenUserAdded(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task HandleEventAsync(UserAddedDomainEvent eventData)
        {
            await _userManager.AssignDefaultRolesAsync(eventData.User);
        }
    }
}
