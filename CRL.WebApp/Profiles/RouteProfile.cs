using AutoMapper;
using CRL.DataModel.Entities;
using CRL.DataService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRL.WebApp.Profiles
{
    public class RouteProfile : Profile
    {
        public RouteProfile()
        {
            CreateMap<RouteEntity, RouteViewModel>();
            CreateMap<RouteViewModel, RouteEntity>();

        }
    }
}
