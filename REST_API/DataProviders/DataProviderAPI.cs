using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using REST_API.Models;
using REST_API.Setup;
using Dapper;

namespace REST_API.DataProviders
{
    public class DataProviderAPI : DataProvider
    {

        /// <summary>
        /// Map for choosing correct data provider
        /// </summary>
        private Dictionary<Type, DataProvider> providers = new Dictionary<Type, DataProvider>();

        public DataProviderAPI()
        {
            InitProviders();
        }

        /// TODO: Check if model is in providers map \\


        public async override Task<IEnumerable<T>> GetAll<T>() => await providers[typeof(T)].GetAll<T>();

        public async override Task<T> Get<T>(int Id) => await providers[typeof(T)].Get<T>(Id);

        public async override Task<IEnumerable<T>> GetRange<T>(int from, int to) => await providers[typeof(T)].GetRange<T>(from, to);

        public async override Task Insert<T>(T model) => await providers[typeof(T)].Insert<T>(model);

        public async override Task Modify<T>(T model) => await providers[typeof(T)].Modify<T>(model);

        public async override Task Delete<T>(int Id) => await providers[typeof(T)].Delete<T>(Id);

        private void InitProviders()
        {
            // Adding initial providers here
            providers.Add(typeof(TransactionHistory), new TransactionHistoryProvider());
            providers.Add(typeof(SalesOrderHeader), new SalesOrderHeaderProvider());
        }

        public void AddProvider(Type type)
        {
            throw new NotImplementedException();
        }
    }
}