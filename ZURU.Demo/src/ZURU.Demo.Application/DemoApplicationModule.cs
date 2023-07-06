using Volo.Abp.AutoMapper;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;
using ZURU.Demo.Domain;

namespace ZURU.Demo.Application;

[DependsOn(
    typeof(DemoDomainModule),
    typeof(AbpFluentValidationModule)
    )]
public class DemoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DemoApplicationModule>();
        });
    }
}
