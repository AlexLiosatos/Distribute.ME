using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Infrastructure;
using DistributeMeProject.Models;
using DistributeMeProject.ViewModels.Products;
using Microsoft.AspNetCore.Identity;

namespace DistributeMeProject.Services
{
    public class RestaurantService
    {

        private RestaurantRepository _repo;

        public RestaurantService(RestaurantRepository repo)
        {
            _repo = repo;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _repo.GetRestaurantById(id);
        }

        public IList<Restaurant> GetRestaurant()
        {
            return _repo.ListRestaurants().ToList();
        }

        public void AddRestaurant(Restaurant restaurant, string userName)
        {
            var user = _repo.GetUserByUsername(userName);
            restaurant.UserId = user.Id;
            _repo.AddRestaurant(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var orig = _repo.GetRestaurantById(restaurant.Id);

            orig.Name = restaurant.Name;
            orig.ZipCodeRegion = restaurant.ZipCodeRegion;
            _repo.SaveChanges();
        }

        public void DeleteRestaurantById(int id)
        {
            var orig = _repo.GetRestaurantById(id);
            _repo.Delete(orig);
            _repo.SaveChanges();
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _repo.Delete(restaurant);
        }

        public IList<Restaurant> GetRestaurantByUserName(string user)
        {
            return _repo.ListRestaurants().Where(u => u.User.Email == user).ToList();
        }

        public void AddRestaurantProduct(int id, Product prod)
        {
            var restProduct = new RestaurantProduct
            {
                Quantity = 1,
                ProductId = prod.Id,
                RestaurantId = id
            };

            var restProd = _repo.GetRestaurantProductById(prod.Id);
            if (restProd != null)
            {
                restProd.Quantity++;
            }
            else
            {
                _repo.AddRestaurantProducts(restProduct);
            }
            _repo.SaveChanges();
        }

        public ICollection<Product> GetRestaurantProducts(int id)
        {
            var resProds = _repo.ListRestaurantProducts().Where(p => p.Restaurant.Id == id).Select(p => new Product
            {
                Name = p.Product.Name,
                Id = p.Product.Id,
                IsOnSale = p.Product.IsOnSale,
                Price = p.Product.Price,
                Quantity = p.Quantity,
                SalePercentage = p.Product.SalePercentage
            }).Where(p => p.Quantity > 0).ToList();
            return resProds;
        }

        public void ConsumeRestaurantProduct(int id, Product product)
        {
            var foundProduct = _repo.GetRestaurantProductById(product.Id);
            if (foundProduct != null)
            {
                if (foundProduct.Quantity > 0)
                    foundProduct.Quantity--;
            }
            _repo.SaveChanges();
        }
    }
}
