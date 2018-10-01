using REST_API.Models;
using REST_API.Setup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace REST_API.DataProvider
{
    public abstract class DataProvider : IDataProvider
    {
        /// <summary>
        /// Used to connect to SQL databasse
        /// </summary>
        protected readonly string connectionString = Config.ConnectionString;


        /// <summary>
        /// Reference for SQL connection
        /// </summary>
        protected SqlConnection sqlConnection;

        public async Task<IEnumerable<T>> GetAll<T>() where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>(int Id) where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task Insert<T>(T product) where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task Modify<T>(T product) where T : Model
        {
            throw new NotImplementedException();
        }

        public async Task Delete<T>(int Id) where T : Model
        {
            throw new NotImplementedException();
        }
    }
}