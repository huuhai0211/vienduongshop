using Shop.Common;
using Shop.Data.Infrastructure;
using Shop.Data.Repositories;
using Shop.Model.Models;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IImportService
    {
        Import Add(Import import);

        void Update(Import import);

        Import Delete(int id);

        IEnumerable<Import> GetAll();

    //    IEnumerable<Import> GetAll(string keyword);

        //IEnumerable<Import> GetAllByCategoryId(int productCategoryID);

        Import GetById(int ID);

        void Save();
    }

    public class ImportService : IImportService
    {
        private IImportRepository _importRepository;
        private IUnitOfWork _unitOfWork;
        public ImportService(IImportRepository importRepository, IUnitOfWork unitOfWork)
        {
            this._importRepository = importRepository;
            this._unitOfWork = unitOfWork;
        }
        public Import Add(Import import)
        {
            return _importRepository.Add(import);
        }

        public  Import Delete(int id)
        {
            return _importRepository.Delete(id);
        }

        public IEnumerable< Import> GetAll()
        {
            return _importRepository.GetAll();
        }

        //public IEnumerable<Import> GetAll(string keyword)
        //{
        //    if (!string.IsNullOrEmpty(keyword))
        //        return _importRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
        //    else
        //        return _importRepository.GetAll();
        //}

        public Import GetById(int ID)
        {
            return _importRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Import import)
        {
            _importRepository.Update(import);

        }
    }

}

