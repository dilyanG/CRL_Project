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
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Routes.Add(entity);
                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
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

        public List<RouteEntity> GetRoutesByCity(int cityId, bool ignoreDirection = true, bool start = true)
        {
            return Context.Routes.Where(r =>
            ignoreDirection ? (r.StartCityId == cityId || r.EndCityId == cityId)
            : start ? r.StartCityId == cityId 
                    : r.EndCityId == cityId).ToList();
        }

        public List<RouteEntity> GetRoutesByCityName(string cityName)
        {
            return Context.Routes.Where(r => r.Name.Contains($"-{cityName}-")).ToList();
        }

        public void Remove(RouteEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Routes.Remove(entity);
                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Update(RouteEntity route)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    RouteEntity forUpdate = Get(route.Id);
                    forUpdate.Distance = route.Distance;
                    forUpdate.ModifiedOn = DateTime.Now; Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}
