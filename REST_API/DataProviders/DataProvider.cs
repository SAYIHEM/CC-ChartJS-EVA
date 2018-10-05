using REST_API.Models;
using REST_API.Setup;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace REST_API.DataProviders
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

        public abstract Task<IEnumerable<T>> GetAll<T>() where T : Model;

        public abstract Task<IEnumerable<T>> GetOneMultiple<T>(int id) where T : Model;

        public abstract Task<T> Get<T>(int Id) where T : Model;

        public abstract Task<IEnumerable<T>> GetRange<T>(int from, int to) where T : Model;

        public abstract Task Insert<T>(T product) where T : Model;

        public abstract Task Modify<T>(T product) where T : Model;

        public abstract Task Delete<T>(int Id) where T : Model;
    }
}