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
    public class CityService : BaseService, ICityService
    {
        public CityService(IDataAccessService dataAccessService) : base(dataAccessService)
        {

        }

        public void AddCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }

        public void CalulateClosenessCentrality(CityEntity city)
        {
            List<RouteEntity> routes = DataAccessService.RouteRepository.GetRoutesByCity(city.Id);
            double allRoutesDistance = 0;
            foreach (RouteEntity route in routes)
            {
                allRoutesDistance += route.Distance;
            }
            if (allRoutesDistance != 0)
            {
                city.ClosenessCentralityCoefficient = 1 / allRoutesDistance;
                UpdateCity(city);
            }
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
    }
}
