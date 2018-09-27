using Microsoft.AspNetCore.Mvc;
using aspnet_core_basic.Models;
using aspnet_core_basic.Services;
using aspnet_core_basic.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace aspnet_core_basic.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        } 
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModels();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            // if (model == null)
            //     return NotFound();
            // if (model == null)
            //     return RedirectToAction("Index"); 
            // if (model == null)
            //     return RedirectToAction(nameof(Index));
            return View(model);
        }
        [HttpGet] 
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}