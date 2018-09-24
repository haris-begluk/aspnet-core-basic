using System.Collections.Generic;
using System.Linq;
using aspnet_core_basic.Models;

namespace aspnet_core_basic.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {


            _restaurants = new List<Restaurant>{
                    new Restaurant {Id=1, Name="First Restaurant"},
                    new Restaurant {Id=2, Name ="Secont Restaurant"},
                    new Restaurant {Id=3, Name="Third Restaurant"}

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}