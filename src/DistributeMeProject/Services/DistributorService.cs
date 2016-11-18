using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistributeMeProject.Infrastructure;
using DistributeMeProject.Models;

namespace DistributeMeProject.Services
{
    public class DistributorService
    {

        private DistributorRepository _repo;

        public DistributorService(DistributorRepository repo)
        {
            _repo = repo;
        }

        public Distributor GetDistributorById(int id)
        {
            return _repo.GetDistributorById(id);
        }

        public IList<Distributor> GetDistributor()
        {
            return _repo.ListDistributors().ToList();
        }


        public IList<Distributor> GetDistributorByUserName(string user)
        {
            //var dist = _repo.ListDistributors().FirstOrDefault(e => e.UserDistributors. == user);

            //var list = _repo.ListDistributors().ToList();
            var dist = (from d in _repo.ListDistributors()
                        from x in d.UserDistributors
                        where x.User.UserName == user
                        select d).ToList();

            return dist;
        }

        public void AddDistributor(Distributor distributor, string userName)
        {
            var user = _repo.GetUserByUsername(userName);


            _repo.AddDistributor(distributor);
            _repo.SaveChanges();
            _repo.PostUserDistributor(new UserDistributor
            {
                UserId = user.Id,
                DistributorId = distributor.Id
            });

            _repo.SaveChanges();
        }

        public void UpdateDistributors(Distributor distributor)
        {
            var orig = _repo.GetDistributorById(distributor.Id);

            orig.Name = distributor.Name;
            orig.ZipCodeRegion = distributor.ZipCodeRegion;
        }

        public void DeleteDistributorById(int id)
        {
            var orig = _repo.GetDistributorById(id);
            _repo.Delete(orig);
            _repo.SaveChanges();
        }

        public void DeleteDistributor(Distributor distributor)
        {
            _repo.Delete(distributor);
        }

        
    }
}
