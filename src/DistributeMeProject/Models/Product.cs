using System.Security.Cryptography.X509Certificates;

namespace DistributeMeProject.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Distributor Owner { get; set; }
        public bool IsOnSale { get; set; }
        public decimal SalePercentage { get; set; }

        public decimal Price { get; set; }
    }
}