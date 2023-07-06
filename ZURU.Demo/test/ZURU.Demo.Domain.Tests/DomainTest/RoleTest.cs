using Xunit;
using ZURU.Demo.Domain;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;
using Shouldly;

namespace ZURU.Demo
{
    public class RoleTest : DemoDomainTestBase
    {
        private readonly IRoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        public RoleTest()
        {
            _roleManager= GetRequiredService<IRoleManager>();
            _roleRepository = GetRequiredService<IRepository<Role>>();
        }

        /// <summary>
        /// 角色名称不能为空
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        [Theory]
        [InlineData("","角色描述")]
        public Task Should_Role_Name_Not_Empty_Test(string roleName,string desc)
        {
            try
            {
                new Role(roleName, desc);
            }
            catch (Exception ex)
            {
                Assert.True(ex is ArgumentException);
            }

            return Task.CompletedTask;
        }

        [Theory]
        [InlineData("Role1", "角色1",false)]
        public async Task Create_Role_Success_Test(string roleName,string desc,bool isDefault)
        {
            await WithUnitOfWorkAsync(async () => {
                await _roleManager.CreateRoleAsync(roleName, desc, isDefault);
            });

            var role = await _roleRepository.FindAsync(p=>p.Name== roleName);
            role.ShouldNotBeNull();
        }
    }
}
