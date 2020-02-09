using CRL.DataAccess.Interfaces;
using CRL.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess
{
    public class DataAccessService : IDataAccessService
    {
        public DataAccessService()
        {
            DataContext context = new DataContext();
            CityRepository = new CityRepository(context);
            RouteRepository = new RouteRepository(context);
        }

        public ICityRepository CityRepository { get; set; }
        public IRouteRepository RouteRepository { get; set; }
    }
}
