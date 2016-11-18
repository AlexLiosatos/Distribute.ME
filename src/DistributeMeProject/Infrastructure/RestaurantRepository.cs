using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Data;
using DistributeMeProject.Models;
using RepositoryPatterns.Repositories;

namespace DistributeMeProject.Infrastructure
{
    public class RestaurantRepository : GenericRepository<Restaurant>
    {

        public RestaurantRepository(ApplicationDbContext db) : base(db)
        {
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.FirstOrDefault(a => a.Id == id);
        }

        public RestaurantProduct GetRestaurantProductById(int id)
        {
            return _db.RestaurantProducts.FirstOrDefault(p => p.Product.Id == id);
        }

        public IQueryable<Restaurant> ListRestaurants()
        {
            return _db.Restaurants;
        }

        public IQueryable<RestaurantProduct> ListRestaurantProducts()
        {
            return _db.RestaurantProducts;
        } 

        public void AddRestaurant(Restaurant restaurant)
        {
            _db.Add(restaurant);
            _db.SaveChanges();
        }

        public void AddRestaurantProducts(RestaurantProduct product)
        {
            _db.RestaurantProducts.Add(product);
            _db.SaveChanges();
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            _db.Remove(restaurant);
            _db.SaveChanges();
        }

        public Restaurant GetRestaurantByZip(string zipCodeRegion)
        {
            return _db.Restaurants.FirstOrDefault(n => n.ZipCodeRegion == zipCodeRegion);
        }
    }
}
