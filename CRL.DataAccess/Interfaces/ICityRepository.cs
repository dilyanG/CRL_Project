using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataAccess.Interfaces
{
    public interface ICityRepository : IDisposable, IBaseRepository<CityEntity>
    {
        int GetCount();
        IEnumerable<CityEntity> GetAllByName(string name);
    }
}
