using ChartJS_Eva.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChartJS_Eva.DataProvider
{
    public class TransactionHistoryProvider : SingleDataProvider
    {

        public async Task<IEnumerable<T>> GetAll<T>() where T : TransactionHistory
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(
                    "spGetTransactionHistory",
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> Get<T>(int Id) where T : TransactionHistory
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", Id);
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(
                    "spGetTransactionHistorys",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}