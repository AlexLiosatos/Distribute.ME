using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Models;

namespace DistributeMeProject.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsOnSale { get; set; }
        public decimal SalePercentage { get; set; }
        public string DistributorName { get; set; }
        public string RestaurantName { get; set; }
        public string DistributorZipCode { get; set; }
        public string RestaurantZipCode { get; set; }
    }

    public class RestaurantProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsOnSale { get; set; }
        public decimal SalePercentage { get; set; }
    }
}
