using ServiceMarketplaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Interfaces
{
    public interface IServiceRepository
    {
        public Task<IEnumerable<Service>> getServices();
    }
}
