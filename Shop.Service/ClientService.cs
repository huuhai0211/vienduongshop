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
    public interface IClientService
    {
        Client Add(Client client);

        void Update(Client client);

        Client Delete(int id);

        IEnumerable<Client> GetAll();

        IEnumerable<Client> GetAll(string keyword);

        Client GetById(int ID);

        void Save();
    }
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        private IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            this._clientRepository = clientRepository;
            this._unitOfWork = unitOfWork;
        }
        public Client Add(Client client)
        {
            return _clientRepository.Add(client);
        }

        public Client Delete(int id)
        {
            return _clientRepository.Delete(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public IEnumerable<Client> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _clientRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _clientRepository.GetAll();
        }

        public Client GetById(int ID)
        {
            return _clientRepository.GetSingleById(ID);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }
    }
}
