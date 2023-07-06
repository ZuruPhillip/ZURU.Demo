using System;
using System.Threading.Tasks;

namespace ZURU.Demo.Domain
{
    public interface IUserManager
    {
        /// <summary>
        /// 新建用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        Task<User> CreateUserAsync(string userName, string password, UserProfile profile);

        /// <summary>
        /// 给新用户赋予默认角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AssignDefaultRolesAsync(User user);
    }
}
