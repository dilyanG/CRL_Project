using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRL.DataAccess.Repositories
{
    public class CityRepository : ICityRepository
    {
        public CityRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(CityEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Cities.Add(entity);
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

        public CityEntity Get(int id)
        {
            return Context.Cities.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<CityEntity> GetAll()
        {
            return Context.Cities.OrderBy(c=>c.CreatedOn);
        }

        public void Remove(CityEntity entity)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Cities.Remove(entity);
                    Context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        public void Update(CityEntity city)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    CityEntity forUpdate = Get(city.Id);
                    forUpdate.Name = city.Name;
                    forUpdate.IsConnected = city.IsConnected;
                    forUpdate.IsLogisticCenter = city.IsLogisticCenter;                    
                    forUpdate.ClosenessCentralityCoefficient = city.ClosenessCentralityCoefficient;
                    forUpdate.ModifiedOn = DateTime.Now;

                    Context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                }
            }
        }
        public int GetCount()
        {
            return Context.Cities.Count();
        }

        public IEnumerable<CityEntity> GetAllByName(string name)
        {
            return Context.Cities.Where(c=>c.Name.Contains(name));
        }

        public bool CheckForLogisticCenter()
        {
            return Context.Cities.Where(c => c.IsLogisticCenter).Any();
        }
        public CityEntity GetLogisticCenter()
        {
            return Context.Cities.Where(c => c.IsLogisticCenter).FirstOrDefault();
        }

        public CityEntity GetByName(string name)
        {
            return Context.Cities.Where(c => c.Name.ToLower()==name.ToLower()).FirstOrDefault();
        }
    }
}
