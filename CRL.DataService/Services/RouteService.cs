using CRL.DataAccess;
using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
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

        private List<RouteEntity> DiscoverRoutes(RouteEntity route)
        {
            List<RouteEntity> discovered = new List<RouteEntity>();
            List<RouteEntity> firstRouteGroup = DataAccessService.RouteRepository.GetRoutesByCity(route.Start.Id, false, false);
            List<RouteEntity> secondRouteGroup = DataAccessService.RouteRepository.GetRoutesByCity(route.End.Id, false, true);
            string newName = "";
            foreach (RouteEntity firstGroupRoute in firstRouteGroup)
            {
                foreach (RouteEntity secondGroupRoute in secondRouteGroup)
                {
                    newName = firstGroupRoute.Name + "-" + secondGroupRoute.Name;
                    if (discovered.Find(d => d.Name == newName) == null)
                    {
                        discovered.Add(new RouteEntity() { Name = newName, Distance = firstGroupRoute.Distance + secondGroupRoute.Distance, Start = firstGroupRoute.Start, End = secondGroupRoute.End });
                    }
                }
            }
            return discovered;
        }

        public RouteEntity Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
