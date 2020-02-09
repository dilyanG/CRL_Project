using CRL.DataAccess;
using CRL.DataModel.Entities;
using CRL.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Services
{
    public class CityService: BaseService, ICityService
    {
        public CityService(DataAccessService dataAccessService): base(dataAccessService)
        {

        }

        public void AddCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }

        public void CalulateClosenessCentrality(CityEntity city)
        {
            List<RouteEntity> routes = DataAccessService.RouteRepository.GetRoutesByCity(city.Id);
        }

        public void DeleteCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }

        public void UpdateCity(CityEntity city)
        {
            DataAccessService.CityRepository.Add(city);
        }
    }
}
