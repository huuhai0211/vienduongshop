using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IImportRepository : IRepository<Import>
    {

    }
    public class ImportRepository : RepositoryBase<Import>, IImportRepository
    {
        public ImportRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
