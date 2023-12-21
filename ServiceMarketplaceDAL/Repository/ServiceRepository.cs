using Microsoft.EntityFrameworkCore;
using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceDAL.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DataContext _dataContext;

        public ServiceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Service>> getServices()
        {
            return await _dataContext.Services.ToListAsync();
        }
    }
}
