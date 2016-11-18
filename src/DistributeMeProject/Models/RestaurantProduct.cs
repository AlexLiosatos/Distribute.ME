using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributeMeProject.Models
{
    public class RestaurantProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }

        public int Quantity { get; set; }
    }
}
