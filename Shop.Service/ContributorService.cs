using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service
{
    public interface IContributorService
    {
        Contributor Add(Contributor contributor);

        void Update(Contributor contributor);

        Contributor Delete(int id);

        IEnumerable<Contributor> GetAll();

        IEnumerable<Contributor> GetAll(string keyword);

        Contributor GetById(int ID);

        void Save();
    }
    public class ContributorService : IContributorService
    {
        private IContributorRepository _contributorRepository;
        private IUnitOfWork _unitOfWork;

        public ContributorService(IContributorRepository contributorRepository, IUnitOfWork unitOfWork)
        {
            this._contributorRepository = contributorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Contributor Add(Contributor contributor)
        {
            return _contributorRepository.Add(contributor);
        }

        public Contributor Delete(int id)
        {
            return _contributorRepository.Delete(id);
        }

        public IEnumerable<Contributor> GetAll()
        {
            return _contributorRepository.GetAll();
        }

        public IEnumerable<Contributor> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _contributorRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _contributorRepository.GetAll();
        }

        public Contributor GetById(int ID)
        {
            return _contributorRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Contributor contributor)
        {
            _contributorRepository.Update(contributor);
        }
    }
}
