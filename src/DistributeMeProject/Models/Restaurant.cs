using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributeMeProject.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RestaurantProduct> RestaurantProducts { get; set; }
        public string ZipCodeRegion { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Restaurant()
        {
            RestaurantProducts = new List<RestaurantProduct>();
        }
    }
}