using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Interfaces
{
    public interface IRouteService
    {
        void AddRoute(RouteEntity route);
        void UpdateRoute(RouteEntity route);
        void DeleteRoute(RouteEntity route);
    }
}
