using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Data;
using DistributeMeProject.Models;
using RepositoryPatterns.Repositories;

namespace DistributeMeProject.Infrastructure
{
    public class DistributorRepository : GenericRepository<Distributor>
    {

        public DistributorRepository(ApplicationDbContext db) : base(db)
        {
        }

        public void PostUserDistributor(UserDistributor userDistributor)
        {
            _db.UserDistributors.Add(userDistributor);
        }

        public Distributor GetDistributorById(int id)
        {
            return _db.Distributors.FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Distributor> ListDistributors()
        {
            return _db.Distributors;
        }

        public void AddDistributor(Distributor distributor)
        {
            _db.Add(distributor);
            _db.SaveChanges();
        }

        public Distributor GetDistributorByName(string distributorName)
        {
            return _db.Distributors.FirstOrDefault(n => n.Name == distributorName);
        }

        public Distributor GetDistributorByZip(string zipCodeRegion)
        {
            return _db.Distributors.FirstOrDefault(n => n.ZipCodeRegion == zipCodeRegion);
        }
    }
}
