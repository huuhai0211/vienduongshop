using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {

    }
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
