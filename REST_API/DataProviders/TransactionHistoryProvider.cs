using REST_API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using REST_API.Exceptions;

namespace REST_API.DataProviders
{
    public class TransactionHistoryProvider : DataProvider
    {

        public async override Task<IEnumerable<T>> GetAll<T>()
        {
            if (typeof(T) != typeof(TransactionHistory)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Production].[TransactionHistory]",
                    null,
                    commandType: CommandType.Text);
            }
        }

        public async override Task<T> Get<T>(int Id)
        {
            if (typeof(T) != typeof(TransactionHistory)) throw new InvalidTypeParameterException();

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

        public async override Task<IEnumerable<T>> GetRange<T>(int from, int to)
        {
            if (typeof(T) != typeof(TransactionHistory)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromTransactionID", from);
                dynamicParameters.Add("@ToTransactionID", to);
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Production].[TransactionHistory] " +
                    "WHERE TransactionID " +
                    "BETWEEN @FromTransactionID AND @ToTransactionID",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

        public override Task Insert<T>(T product)
        {
            throw new NotImplementedException();
        }

        public override Task Modify<T>(T product)
        {
            throw new NotImplementedException();
        }

        public override Task Delete<T>(int Id)
        {
            throw new NotImplementedException();
        }


    }
}