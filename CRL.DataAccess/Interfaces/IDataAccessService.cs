using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess.Interfaces
{
    public interface IDataAccessService
    {
        ICityRepository CityRepository { get; set; }
        IRouteRepository RouteRepository { get; set; }
    }
}
