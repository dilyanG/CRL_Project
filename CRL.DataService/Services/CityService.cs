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
            DataAccessService.CityRepository.Update(city);
        }

        public CityEntity FindLogisticCenter()
        {
            //defining a starting city needed for Prim's algorithm
            CityEntity start = DataAccessService.CityRepository.GetAll().FirstOrDefault();

            //getting the previous logistic Center
            CityEntity previousLogisticCenter = DataAccessService.CityRepository.GetLogisticCenter();

            CityEntity newLogisticCenter = algorithms.FindLogisticCenter(start);
            if (previousLogisticCenter?.Id != newLogisticCenter.Id)
            {
                previousLogisticCenter.IsLogisticCenter = false;
                newLogisticCenter.IsLogisticCenter = true;
                DataAccessService.CityRepository.Update(previousLogisticCenter);
                DataAccessService.CityRepository.Update(newLogisticCenter);
            }
            return newLogisticCenter;
        }
        public bool CheckForLogisticCenter()
        {
            return this.DataAccessService.CityRepository.CheckForLogisticCenter();
        }
        public bool CheckCityByName(int id, string name) {

            CityEntity byName = DataAccessService.CityRepository.GetByName(name);
            if (byName == null) return true;
            else if (byName.Id == id) return true;
            else return false;
        }
    }
}
