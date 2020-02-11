using CRL.DataAccess;
using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
using CRL.DataService.Helpers;
using CRL.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRL.DataService.Services
{
    public class RouteService : BaseService, IRouteService
    {

        public RouteService(IDataAccessService dataAccessService) : base(dataAccessService)
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

        public List<RouteEntity> GetAll()
        {
            return DataAccessService.RouteRepository.GetAll().ToList();
        }


        public RouteEntity Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
