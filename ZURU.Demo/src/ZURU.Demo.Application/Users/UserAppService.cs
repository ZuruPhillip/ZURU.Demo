using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using ZURU.Demo.Domain;

namespace ZURU.Demo.Application
{
    public class UserAppService : DemoAppService, IUserAppService
    {
        private readonly IUserManager _userManager;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public UserAppService(
            IUserManager userManager, 
            IRepository<User> userRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _userManager= userManager;
            _userRepository= userRepository;
            _unitOfWorkManager= unitOfWorkManager;
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            //TODO:参数验证

            //创建用户，用子工作单元提交
            using (var uow = _unitOfWorkManager.Begin(requiresNew: true))
            {
                //创建新用户
                await _userManager.CreateUserAsync(
                        dto.UserName,
                        dto.Password,
                        new UserProfile(dto.Mobile, dto.Email, dto.Address)
                        );

                await uow.CompleteAsync();
            }

              
            //因为上面已经提交了工作单元，所以这里能查出来数据
            var aaa =await _userRepository.FindAsync(p=>p.UserName==dto.UserName);
        }
    }
}
