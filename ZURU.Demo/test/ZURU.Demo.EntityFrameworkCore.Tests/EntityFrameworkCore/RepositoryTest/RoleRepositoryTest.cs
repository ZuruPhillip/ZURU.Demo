using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;
using ZURU.Demo.Domain;

namespace ZURU.Demo.EntityFrameworkCore
{
    public class RoleRepositoryTest: DemoEntityFrameworkCoreTestBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRepository<Permission> _permissionRepository;
        public RoleRepositoryTest()
        {
            _roleRepository = GetRequiredService<IRoleRepository>();
            _permissionRepository= GetRequiredService<IRepository<Permission>>();
        }

        /// <summary>
        /// 测试自定义仓储是否可以查出实体
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Find_By_Name_Test()
        {
            /*
             * 如果聚合根有实体要能查询出实体
             */

            //创建一条权限
            var permissionName = "OrderManager.Create";
            await WithUnitOfWorkAsync(async ()=> {
                await _permissionRepository.InsertAsync(new Permission(permissionName, "订单管理-创建订单"));
            });

            var permission = await _permissionRepository.FindAsync(p=>p.Name== permissionName);
            permission.ShouldNotBeNull();


            //创建一个带权限的角色
            var role = new Role("Role1","角色1");
            role.AddPermission(permission.Id);
            await WithUnitOfWorkAsync(async () => {
                await _roleRepository.InsertAsync(role);
            });

            var obj = await _roleRepository.FindAsync(p=>p.Name== role.Name);
            obj.ShouldNotBeNull();
            obj.PermissionGrants.Count.ShouldBe(1);//只有一条权限
        }
    }
}
