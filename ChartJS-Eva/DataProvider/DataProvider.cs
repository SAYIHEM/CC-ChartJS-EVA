using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChartJS_Eva.Models;
using ChartJS_Eva.Setup;

namespace ChartJS_Eva.DataProvider
{
    public class DataProvider : IDataProvider
    {

        /// <summary>
        /// Used to connect to SQL databasse
        /// </summary>
        private readonly string connectionString = Config.ConnectionString;


        /// <summary>
        /// Reference to SQL connection
        /// </summary>
        private SqlConnection sqlConnection;

        public DataProvider()
        {
            
        }

        public Task<IEnumerable<T>> GetAll<T>() where T : Model
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(int Id) where T : Model
        {
            throw new NotImplementedException();
        }

        public Task Insert<T>(T product) where T : Model
        {
            throw new NotImplementedException();
        }

        public Task Modify<T>(T product) where T : Model
        {
            throw new NotImplementedException();
        }

        public Task Delete<T>(int Id) where T : Model
        {
            throw new NotImplementedException();
        }
    }
}