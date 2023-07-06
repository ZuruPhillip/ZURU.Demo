using System.Threading.Tasks;

namespace ZURU.Demo.Application
{
    public interface IUserAppService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task RegisterAsync(RegisterUserDto dto);
    }
}
