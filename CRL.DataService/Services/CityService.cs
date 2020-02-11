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
    public class CityService : BaseService, ICityService
    {
        Algorithms algorithms;


        public CityService(IDataAccessService dataAccessService) : base(dataAccessService)
        {
            algorithms = new Algorithms(dataAccessService);
        }

        public void AddCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }

        public void CalulateClosenessCentrality(CityEntity city)
        {

        }

        public void DeleteCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }

        public CityEntity Get(int id)
        {
            return DataAccessService.CityRepository.Get(id);
        }

        public List<CityEntity> GetAll()
        {
            return DataAccessService.CityRepository.GetAll().ToList();
        }

        public List<CityEntity> GetAllByName(string name)
        {
            return DataAccessService.CityRepository.GetAllByName(name).ToList();
        }

        public void UpdateCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }

        public CityEntity FindLogisticCenter()
        {
            CityEntity start = DataAccessService.CityRepository.GetAll().FirstOrDefault();

            CityEntity logisticCenter = algorithms.FindLogisticCenter(start);
            logisticCenter.IsLogisticCenter = true;
            DataAccessService.CityRepository.Update(logisticCenter);
            return logisticCenter;
        }
    }
}
