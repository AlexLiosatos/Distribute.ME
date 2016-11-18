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
    public class DistributorsController : Controller
    {

        private DistributorService _service;

        public DistributorsController(DistributorService service)
        {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "DistributorOnly")]
        public IEnumerable<Distributor> Get()
        {
            return _service.GetDistributor();
        }

        // GET: api/values
        [HttpGet("distributor")]
        [Authorize(Policy = "DistributorOnly")]
        public ICollection<Distributor> GetUser()
        {
            return _service.GetDistributorByUserName(User.Identity.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Policy = "DistributorOnly")]
        public Distributor Get(int id)
        {
            return _service.GetDistributorById(id);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public void Post([FromBody]Distributor distributor)
        {
            _service.AddDistributor(distributor, User.Identity.Name);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Distributor distributor)
        {
            _service.UpdateDistributors(distributor);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteDistributorById(id);
        }
    }
}
