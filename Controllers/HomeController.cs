using Microsoft.AspNetCore.Mvc;
namespace aspnet_core_basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return this.BadRequest(); 
            // return this.File();
            return Content("Home controller");
        }
    }
}