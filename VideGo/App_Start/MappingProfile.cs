using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideGo.DTOs;
using VideGo.Models;

namespace VideGo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

        }
    }
}