using System.ComponentModel.DataAnnotations;
using aspnet_core_basic.Models;

namespace aspnet_core_basic.ViewModels
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}