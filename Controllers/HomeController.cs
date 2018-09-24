using Microsoft.AspNetCore.Mvc;
using aspnet_core_basic.Models;
namespace aspnet_core_basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Restaurant(1, "New Restaurant");
            return View(model);
        }
    }
}