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
            // Map Domain to DTO
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();


            // Map DTO to Domain
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c=>c.Id,opt=>opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}