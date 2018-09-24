using System.Collections.Generic;
using aspnet_core_basic.Models;

namespace aspnet_core_basic.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}