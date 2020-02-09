using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Interfaces
{
    public interface IRouteService
    {
        List<RouteEntity> GetAll();
        RouteEntity Get(int id);
        void AddRoute(RouteEntity route);
        void UpdateRoute(RouteEntity route);
        void DeleteRoute(RouteEntity route);
    }
}
