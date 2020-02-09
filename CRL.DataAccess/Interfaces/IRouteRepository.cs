using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess.Interfaces
{
    public interface IRouteRepository : IDisposable, IBaseRepository<RouteEntity>
    {
        List<RouteEntity> GetRoutesByCity(int cityId, bool ignoreDirection = true, bool start = true);
        List<RouteEntity> GetRoutesByCityName(string cityName);
    }
}
