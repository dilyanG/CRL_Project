using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRL.DataAccess.Repositories
{
    public class RouteRepository : IRouteRepository
    {

        public RouteRepository(DataContext context)
        {
            this.Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(RouteEntity entity)
        {
            Context.Routes.Add(entity);
            Context.Database.CurrentTransaction.Commit();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public RouteEntity Get(int id)
        {
            return Context.Routes.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<RouteEntity> GetAll()
        {
            return Context.Routes;
        }

        public List<RouteEntity> GetRoutesByCity(int cityId)
        {
            return Context.Routes.Where(r => r.StartCityId == cityId || r.EndCityId == cityId).ToList();
        }

        public List<RouteEntity> GetRoutesByCityName(string cityName)
        {
            return Context.Routes.Where(r => r.Name.Contains($"-{cityName}-")).ToList();
        }

        public void Remove(RouteEntity entity)
        {
            Context.Routes.Remove(entity);
            Context.Database.CurrentTransaction.Commit();
        }

        public void Update(RouteEntity route)
        {
            RouteEntity forUpdate = Get(route.Id);
            forUpdate.Distance = route.Distance;
            forUpdate.ModifiedOn = DateTime.Now;
            Context.SaveChanges();
            Context.Database.CurrentTransaction.Commit();
        }
    }
}
