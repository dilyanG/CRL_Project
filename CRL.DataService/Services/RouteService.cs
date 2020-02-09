using CRL.DataAccess;
using CRL.DataModel.Entities;
using CRL.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Services
{
    public class RouteService: BaseService, IRouteService
    {
        public RouteService(DataAccessService dataAccessService) : base(dataAccessService)
        {

        }

        public void AddRoute(RouteEntity route)
        {
            DataAccessService.RouteRepository.Add(route);
        }

        public void DeleteRoute(RouteEntity route)
        {
            DataAccessService.RouteRepository.Remove(route);
        }

        public void UpdateRoute(RouteEntity route)
        {
            DataAccessService.RouteRepository.Update(route);
        }
    }
}
