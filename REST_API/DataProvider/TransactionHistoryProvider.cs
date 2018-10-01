using REST_API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace REST_API.DataProvider
{
    public class TransactionHistoryProvider : DataProvider
    {

        public async Task<IEnumerable<T>> GetAll<T>() where T : TransactionHistory
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Production].[TransactionHistory]",
                    null,
                    commandType: CommandType.Text);
            }
        }

        public async Task<T> Get<T>(int Id) where T : TransactionHistory
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@TransactionID", Id);
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Production].[TransactionHistory] WHERE TransactionID=@TransactionID",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }
    }
}