using AutoMapper;
using CRL.DataModel.Entities;
using CRL.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRL.WebApp.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntity, CityViewModel>();
            CreateMap<CityViewModel, CityEntity>();
        }
    }
}
