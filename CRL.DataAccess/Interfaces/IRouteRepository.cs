using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess.Interfaces
{
    public interface IRouteRepository : IDisposable, IBaseRepository<RouteEntity>
    {
        List<RouteEntity> GetRoutesByCity(int cityId, int[] without);
        List<RouteEntity> GetRoutesByCities(int[] ids);
        List<RouteEntity> GetRoutesByCityName(string cityName);
    }
}
