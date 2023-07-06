using System;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using Xunit;
using ZURU.Demo.Application;

namespace ZURU.Demo
{
    public class RoleAppServiceTest: DemoApplicationTestBase
    {
        private readonly IRoleAppService _roleAppService;
        public RoleAppServiceTest()
        {
            _roleAppService = GetRequiredService<IRoleAppService>();
        }

        /// <summary>
        /// 创建Role时参数验证
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_AbpValidationException_When_Create_Role_Test()
        {
            var dto = new CreateRoleDto();

            try
            {
                await _roleAppService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                Assert.True(ex is AbpValidationException);
            }
        }

    }
}
