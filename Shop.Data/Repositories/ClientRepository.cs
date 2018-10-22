using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {

    }
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
