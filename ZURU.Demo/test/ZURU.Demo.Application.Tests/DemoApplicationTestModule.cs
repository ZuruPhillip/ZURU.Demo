using Volo.Abp.Modularity;
using ZURU.Demo.Application;

namespace ZURU.Demo;

[DependsOn(
    typeof(DemoApplicationModule),
    typeof(DemoDomainTestModule)
    )]
public class DemoApplicationTestModule : AbpModule
{

}
