using CRL.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRL.DataService.Services
{
    public abstract class BaseService
    {
        public readonly DataAccessService DataAccessService;

        public BaseService(DataAccessService dataAccessService)
        {
            DataAccessService = dataAccessService;
        }
    }
}
