using System.Collections.Generic;
using aspnet_core_basic.Models;

namespace aspnet_core_basic.ViewModels
{
    public class HomeIndexViewModels
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}