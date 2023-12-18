using AutoMapper;
using ServiceMarketplaceBLL.DTO;
using ServiceMarketplaceDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMarketplaceBLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO >().ReverseMap();
            CreateMap<CreateReviewDTO, Review>().ReverseMap();
        }
    }
}
