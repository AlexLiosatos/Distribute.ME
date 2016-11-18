using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Models;
using DistributeMeProject.Services;
using DistributeMeProject.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DistributeMeProject.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IQueryable<ProductViewModel> GetProducts()
        {
            return _service.GetProducts();
        }

        [HttpGet("{id}")]
        public IQueryable<ProductViewModel> GetDistributorItems(int id)
        {
            return _service.GetDistributorItems(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]ProductViewModel item)
        {
            _service.AddProducts(item);
        }

        // POST api/values
        [HttpPost("{id}")]
        public void PostRest([FromBody]ProductViewModel item)
        {
            _service.AddRestaurantProducts(item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        [HttpPut]
        public void Put([FromBody]Product product)
        {
            _service.UpdateProduct(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
