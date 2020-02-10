using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Interfaces
{
    public interface ICityService
    {
        List<CityEntity> GetAll();
        List<CityEntity> GetAllByName(string name);
        CityEntity Get(int id);
        void AddCity(CityEntity city);
        void UpdateCity(CityEntity city);
        void DeleteCity(CityEntity city);
        void CalulateClosenessCentrality(CityEntity city);

    }
}
