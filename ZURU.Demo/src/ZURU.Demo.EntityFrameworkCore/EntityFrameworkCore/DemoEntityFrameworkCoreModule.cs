using Volo.Abp.Modularity;
using ZURU.Demo.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace ZURU.Demo.EntityFrameworkCore;

[DependsOn(
    typeof(DemoDomainModule),
    typeof(AbpEntityFrameworkCoreMySQLModule)
    )]
public class DemoEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DemoDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
                /* The main point to change your DBMS.
                 * See also DemoMigrationsDbContextFactory for EF Core tooling. */
            options.UseMySQL();
        });

        #region 配置聚合根的明细默认查询策略
        /*
         * http://www.manongjc.com/detail/23-ozymoxhcbkpofel.html
         * https://docs.abp.io/en/abp/5.2/Entity-Framework-Core
         */
        //Configure<AbpEntityOptions>(options =>
        //{
        //    options.Entity<Role>(ops =>
        //    {
        //        ops.DefaultWithDetailsFunc = query => query.Include(o => o.PermissionGrants);
        //    });
        //});
        #endregion

    }
}
