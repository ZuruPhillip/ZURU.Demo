using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZURU.Demo.Application
{
    /// <summary>
    /// 权限
    /// </summary>
    public interface IPermissionAppService
    {
        /// <summary>
        /// 新建一个操作权限
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<PermissionDto> CreateAsync(CreatePermissionDto dto);
    }
}
