using CRL.DataAccess.Interfaces;
using CRL.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Helpers
{
    public class Algorithms
    {
        private readonly IDataAccessService dataAccessService;

        public Algorithms(IDataAccessService dataAccessService)
        {
            this.dataAccessService = dataAccessService;
        }

        public Dictionary<CityEntity, double> CalculateClosenessCentralityCoefficient(CityEntity node)
        {

            return null;
        }

        private void ApplyPrim(CityEntity node)
        {
            List<CityEntity> visited = new List<CityEntity>();
            visited.Add(node);



        }
    }
}
