using Volo.Abp.Application.Services;

namespace ZURU.Demo.Application;

/* Inherit your application services from this class.
 */
public abstract class DemoAppService : ApplicationService
{
    protected DemoAppService()
    {
        //LocalizationResource = typeof(DemoResource);
    }
}
