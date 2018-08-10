using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Debaser.Models;
using Debaser.Dtos;
namespace Debaser.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<DebaserData, DebaserDataDto>();
        }
    }
}