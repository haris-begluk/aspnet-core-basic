using Microsoft.AspNetCore.Mvc;
using aspnet_core_basic.Models;
using aspnet_core_basic.Services;

namespace aspnet_core_basic.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult Index()
        {
            var model = _restaurantData.GetAll();
            return View(model);
        }
    }
}