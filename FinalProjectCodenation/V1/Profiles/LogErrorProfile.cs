using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinalProjectCodenation.Models;
using FinalProjectCodenation.V1.Dtos;

namespace FinalProjectCodenation.V1.Profiles
{
    public class LogErrorProfile : Profile
    {
        public LogErrorProfile()
        {
            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Sector, SectorDto>().ReverseMap();

        }
    }
}
