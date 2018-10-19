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
    public interface IWarehouseService
    {
        Warehouse Add(Warehouse warehouse);

        void Update(Warehouse warehouse);

        Warehouse Delete(int id);

        IEnumerable<Warehouse> GetAll();

        IEnumerable<Warehouse> GetAll(string keyword);

        Warehouse GetById(int ID);

        void Save();
    }

    public class WarehouseService : IWarehouseService
    {
        private IWarehouseRepository _warehouseRepository;
        private IUnitOfWork _unitOfWork;

        public WarehouseService(IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork)
        {
            this._warehouseRepository = warehouseRepository;
            this._unitOfWork = unitOfWork;
        }

        public Warehouse Add(Warehouse warehouse)
        {
            return _warehouseRepository.Add(warehouse);
        }

        public Warehouse Delete(int id)
        {
            return _warehouseRepository.Delete(id);
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return _warehouseRepository.GetAll();
        }

        public IEnumerable<Warehouse> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _warehouseRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _warehouseRepository.GetAll();
        }

        public IEnumerable<Warehouse> GetAllByParentId(int parentID)
        {
            return _warehouseRepository.GetMulti(x => x.Status);
        }

        public Warehouse GetById(int id)
        {
            return _warehouseRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Warehouse warehouse)
        {
            _warehouseRepository.Update(warehouse);
        }
    }
}
