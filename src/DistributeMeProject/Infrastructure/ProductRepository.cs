using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Data;
using DistributeMeProject.Models;
using DistributeMeProject.ViewModels.Products;

namespace DistributeMeProject.Infrastructure
{
    public class ProductRepository
    {

        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            var prod = from e in _db.Products
                       select new ProductViewModel
                       {
                           Id = e.Id,
                           Name = e.Name,
                           Quantity = e.Quantity,
                           Price = e.Price,
                           IsOnSale = e.IsOnSale,
                           SalePercentage = e.SalePercentage,
                           DistributorName = e.Owner.Name,
                       };

            return prod;
        }

        public IQueryable<ProductViewModel> GetProducts(int id)
        {
            return from e in _db.Products
                select new ProductViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Quantity = e.Quantity,
                    Price = e.Price,
                    IsOnSale = e.IsOnSale,
                    SalePercentage = e.SalePercentage,
                    DistributorName = e.Owner.Name
                };
        }

        public void AddProduct(Product item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void AddRestaurantProduct(RestaurantProduct item)
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _db.Products.FirstOrDefault(a => a.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            var orig = GetProductById(product.Id);

            orig.Id = product.Id;
            orig.Name = product.Name;
            orig.Price = product.Price;
            orig.IsOnSale = product.IsOnSale;
            orig.Owner = product.Owner;
            orig.SalePercentage = product.SalePercentage;
            orig.Quantity = product.Quantity;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = GetProductById(id);

            _db.Remove(product);
            _db.SaveChanges();
        }

    }
}
