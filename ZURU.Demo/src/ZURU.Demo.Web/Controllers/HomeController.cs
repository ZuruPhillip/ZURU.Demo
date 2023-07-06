using Microsoft.AspNetCore.Mvc;

namespace ZURU.Demo.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("~/swagger");
        }
    }
}
