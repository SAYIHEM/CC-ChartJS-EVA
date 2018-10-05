using Dapper;
using REST_API.Exceptions;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.DataProviders
{
    public class CustomerProvider : DataProvider
    {
        public async override Task Delete<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public async override Task<T> Get<T>(int Id)
        {
            if (typeof(T) != typeof(Customer)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CustomerID", Id);
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(
                    "SELECT * " +
                    "FROM [AdventureWorks2017].[Sales].[Customer] " +
                    "WHERE CustomerID=@CustomerID",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

        public async override Task<IEnumerable<T>> GetAll<T>()
        {
            if (typeof(T) != typeof(Customer)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * " +
                    "FROM [AdventureWorks2017].[Sales].[Customer]",
                    null,
                    commandType: CommandType.Text);
            }
        }

        public async override Task<IEnumerable<T>> GetRange<T>(int from, int to)
        {
            if (typeof(T) != typeof(Customer)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromCustomerID", from);
                dynamicParameters.Add("@ToCustomerID", to);
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * " +
                    "FROM [AdventureWorks2017].[Sales].[Customer] " +
                    "WHERE CustomerID " +
                    "BETWEEN @FromCustomerID AND @ToCustomerID",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

        public async override Task Insert<T>(T product)
        {
            throw new NotImplementedException();
        }

        public async override Task Modify<T>(T product)
        {
            throw new NotImplementedException();
        }
    }
}
