using AutoMapper;
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
        private readonly IMapper _mapper;
        public ServiceService (IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ServiceDTO>> getServices()
        {
            var services = await _serviceRepository.getServices();
            return services.Select(s => _mapper.Map<ServiceDTO>(s));
        }
    }
}
