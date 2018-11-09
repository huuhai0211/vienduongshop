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
    public interface IImportDetailService
    {
        ImportDetail Add(ImportDetail importDetail);

        void Update(ImportDetail importDetail);

        ImportDetail Delete(int id);

        IEnumerable<ImportDetail> GetAll();

        //IEnumerable<ImportDetail> GetAll(string keyword);

        //IEnumerable<ImportDetail> GetAllByProductId(int ProductID);

        ImportDetail GetById(int ID);

        void Save();
    }
    public class ImportDetailService : IImportDetailService
    {
        private IImportDetailRepository _importDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ImportDetailService(IImportDetailRepository importDetailRepository, IUnitOfWork unitOfWork)
        {
            this._importDetailRepository = importDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public ImportDetail Add(ImportDetail importDetail)
        {
            return _importDetailRepository.Add(importDetail);

        }          

        public ImportDetail Delete(int id)
        {
            return _importDetailRepository.Delete(id);
        }

        public IEnumerable<ImportDetail> GetAll()
        {
            return _importDetailRepository.GetAll();
        }

        //public IEnumerable<ImportDetail> GetAll(string keyword)
        //{
        //    if (!string.IsNullOrEmpty(keyword))
        //        return _productRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
        //    else
        //        return _productRepository.GetAll();
        //}

        //public IEnumerable<ImportDetail> GetAllByProductId(int ProductID)
        //{
        //    return _importDetailRepository.GetMulti(x => x.Status && x.ProductID == productCategoryID);
        //}

        public ImportDetail GetById(int id)
        {
            return _importDetailRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ImportDetail importDetail)
        {
            _importDetailRepository.Update(importDetail);

        }
     }
 }

