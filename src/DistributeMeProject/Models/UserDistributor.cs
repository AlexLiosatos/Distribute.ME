using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DistributeMeProject.Models
{
    public class UserDistributor
    {
        public int DistributorId { get; set; }
        [ForeignKey("DistributorId")]
        public Distributor Distributor { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
