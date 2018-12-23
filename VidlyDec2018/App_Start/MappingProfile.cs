using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyDec2018.Models;
using VidlyDec2018.Models.Dto;

namespace VidlyDec2018.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //Dto uses reflection here,m to see details of the type at runtime, and use this to map one to the other
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}