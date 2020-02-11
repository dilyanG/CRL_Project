using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
using Microsoft.EntityFrameworkCore;
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
            entity.Start = Context.Cities.Where(c => c.Id == entity.Start.Id).FirstOrDefault();
            entity.End = Context.Cities.Where(c => c.Id == entity.End.Id).FirstOrDefault();

            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Routes.Add(entity);
                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
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
            return Context.Routes.Include(r => r.Start).Include(r => r.End);
        }

        public List<RouteEntity> GetRoutesByCity(int cityId, int[] without)
        {
            return Context.Routes.Include(r => r.Start).Include(r => r.End)
                .Where(r => (r.Start.Id == cityId || r.End.Id == cityId)
                            && !without.Contains(r.End.Id) 
                            && !without.Contains(r.Start.Id)).ToList();
        }

        public List<RouteEntity> GetRoutesByCities(int[] ids)
        {
            return Context.Routes.Where(r => ids.Contains(r.Start.Id)).ToList();
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
