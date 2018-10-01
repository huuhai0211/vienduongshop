using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IImportDetailRepository : IRepository<ImportDetail>
    {
    }
    public class ImportDetailRepository : RepositoryBase<ImportDetail>, IImportDetailRepository
    {
        public ImportDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
