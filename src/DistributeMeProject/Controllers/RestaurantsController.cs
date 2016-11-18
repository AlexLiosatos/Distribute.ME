using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Models;
using DistributeMeProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DistributeMeProject.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantsController : Controller
    {

        private RestaurantService _service;

        public RestaurantsController(RestaurantService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "RestaurantOnly")]
        public IEnumerable<Restaurant> Get()
        {
            return _service.GetRestaurant();
        }

        //Get Only Users
        [HttpGet("restaurant")]
        [Authorize(Policy = "RestaurantOnly")]
        public ICollection<Restaurant> GetUser()
        {
            return _service.GetRestaurantByUserName(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Policy = "RestaurantOnly")]
        public Restaurant Get(int id)
        {
            return _service.GetRestaurantById(id);
        }

        // GET api/values/5
        [HttpGet("resprods/{id}")]
        [Authorize(Policy = "RestaurantOnly")]
        public ICollection<Product> GetRestProducts(int id)
        {
            return _service.GetRestaurantProducts(id);
        }

        // POST api/values
        [HttpPost]
        [Authorize] // Forces Login To Post
        public void Post([FromBody]Restaurant restaurant)
        {
            _service.AddRestaurant(restaurant, User.Identity.Name);
        }

        // POST api/values
        [HttpPost("resprods/{id}")]
        [Authorize] // Forces Login To Post
        public void Post(int id, [FromBody]Product prod)
        {
            _service.AddRestaurantProduct(id, prod);
        }

        [HttpPut]
        public void Put([FromBody] Restaurant restaurant)
        {
            _service.UpdateRestaurant(restaurant);
        }

        // PUT api/values/5
        [HttpPut("consume/{id}")]
        public void PutRestProduct(int id, [FromBody]Product product)
        {
            _service.ConsumeRestaurantProduct(id, product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteRestaurantById(id);
        }

        //// DELETE api/values
        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    _service.DeleteRestaurantById(id);
        //}
    }
}
