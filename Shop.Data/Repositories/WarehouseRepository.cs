using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        
    }
    public class WarehouseRepository : RepositoryBase<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
