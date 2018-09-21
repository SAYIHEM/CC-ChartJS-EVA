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
    public class DataProviderAPI : DataProvider
    {

        /// <summary>
        /// Map for choosing correct data provider
        /// </summary>
        private Dictionary<Type, DataProvider> providers = new Dictionary<Type, DataProvider>();


        public async Task<IEnumerable<T>> GetAll<T>() where T : Model => await providers[typeof(T)].GetAll<T>();

        public async Task<T> Get<T>(int Id) where T : Model => await providers[typeof(T)].Get<T>(Id);

        public async Task Insert<T>(T model) where T : Model => await providers[typeof(T)].Insert<T>(model);

        public async Task Modify<T>(T model) where T : Model => await providers[typeof(T)].Modify<T>(model);

        public async Task Delete<T>(int Id) where T : Model => await providers[typeof(T)].Delete<T>(Id);

        private void InitProviders()
        {
            // Adding initial providers here
            providers.Add(typeof(TransactionHistory), new TransactionHistoryProvider());
        }

        public void AddProvider(Type type)
        {
            throw new NotImplementedException();
        }
    }
}