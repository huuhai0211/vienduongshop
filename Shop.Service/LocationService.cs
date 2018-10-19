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
    public interface ILocationService
    {
        Location Add(Location location);

        void Update(Location location);

        Location Delete(int id);

        IEnumerable<Location> GetAll();

        IEnumerable<Location> GetAll(string keyword);

        IEnumerable<Location> GetAllByWarehouseId(int warehouseID);

        Location GetById(int ID);

        void Save();
    }
    public class LocationService : ILocationService
    {
        private ILocationRepository _locationRepository;
        private IUnitOfWork _unitOfWork;

        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
        {
            this._locationRepository = locationRepository;
            this._unitOfWork = unitOfWork;
        }

        public Location Add(Location location)
        {
            return location = _locationRepository.Add(location);
        }

        public Location Delete(int id)
        {
            return _locationRepository.Delete(id);
        }

        public IEnumerable<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public IEnumerable<Location> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _locationRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _locationRepository.GetAll();
        }

        public IEnumerable<Location> GetAllByWarehouseId(int warehouseID)
        {
            return _locationRepository.GetMulti(x => x.Status && x.WarehouseID == warehouseID);
        }

        public Location GetById(int id)
        {
            return _locationRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Location location)
        {

           _locationRepository.Update(location);
        }
    }
}
