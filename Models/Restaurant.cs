using System.ComponentModel.DataAnnotations;
namespace aspnet_core_basic.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant Name")]
        //[DataType(DataType.Password)] 
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}