using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Infrastructure;
using DistributeMeProject.Models;
using DistributeMeProject.ViewModels.Products;

namespace DistributeMeProject.Services
{
    public class ProductService
    {

        private ProductRepository _repo;
        private DistributorRepository _distRepo;
        private RestaurantRepository _restRepo;

        public ProductService(ProductRepository repo, DistributorRepository distRepo, RestaurantRepository restRepo)
        {
            _repo = repo;
            _distRepo = distRepo;
            _restRepo = restRepo;
        }

        public IQueryable<ProductViewModel> GetDistributorItems(int id)
        {
            return _repo.GetProducts(id);
        }

        public void AddProducts(ProductViewModel item)
        {
            _repo.AddProduct(new Product
            {
                Id = item.Id,
                Name = item.Name,
                Quantity = item.Quantity,
                Owner = _distRepo.GetDistributorByName(item.DistributorName),
                IsOnSale = item.IsOnSale,
                SalePercentage = item.SalePercentage,
                Price = item.Price
            });
        }

        public void AddRestaurantProducts(ProductViewModel item)
        {
            _repo.AddRestaurantProduct(new RestaurantProduct
            {
                Quantity = item.Quantity,
                Product = new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Owner = _distRepo.GetDistributorByName(item.DistributorName),
                    IsOnSale = item.IsOnSale,
                    SalePercentage = item.SalePercentage,
                    Price = item.Price
                },
                Restaurant = _restRepo.GetRestaurantByZip(item.RestaurantZipCode)
            });

        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            return _repo.GetProducts();
        }

        public void UpdateProduct(Product product)
        {
            _repo.UpdateProduct(product);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        
    }
}
