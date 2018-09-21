using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChartJS_Eva.Models;
using ChartJS_Eva.Setup;
using Dapper;

namespace ChartJS_Eva.DataProvider
{
    public class DataProviderAPI : IDataProvider
    {
        public async Task<IEnumerable<T>> GetAll<T>() where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>(int Id) where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task Insert<T>(T model) where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task Modify<T>(T model) where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task Delete<T>(int Id) where T : Model
        {
            throw new NotImplementedException();
        }
    }
}