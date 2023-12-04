using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceBLL.Interfaces;
using ServiceMarketplaceDAL.Entities;
using ServiceMarketplaceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService (IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<IEnumerable<ServiceDTO>> getServices()
        {
            var services = await _serviceRepository.getServices();
            return services.Select(s => new ServiceDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description
            });
        }
    }
}
