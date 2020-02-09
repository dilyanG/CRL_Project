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
            Context.Cities.Add(entity);
            Context.Database.CurrentTransaction.Commit();
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
            return Context.Cities;
        }

        public void Remove(CityEntity entity)
        {
            Context.Cities.Remove(entity);
            Context.Database.CurrentTransaction.Commit();
        }

        public void Update(CityEntity city)
        {
            CityEntity forUpdate = Get(city.Id);
            forUpdate.Name = city.Name;
            forUpdate.IsConnected = city.IsConnected;
            forUpdate.IsLogisticCenter = city.IsLogisticCenter;
            forUpdate.ModifiedOn = DateTime.Now;
            Context.SaveChanges();
            Context.Database.CurrentTransaction.Commit();
        }
    }
}
