using ZURU.Demo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ZURU.Demo;

[DependsOn(
    typeof(DemoEntityFrameworkCoreTestModule)
    )]
public class DemoDomainTestModule : AbpModule
{

}
