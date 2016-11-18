using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistributeMeProject.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public string ZipCodeRegion { get; set; }
        public ICollection<UserDistributor> UserDistributors { get; set; } 
    }
}
