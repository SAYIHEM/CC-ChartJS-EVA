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
    public class SalesOrderHeaderProvider : DataProvider
    {
        public async override Task Delete<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable<T>> GetOneMultiple<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public async override Task<T> Get<T>(int Id)
        {
            if (typeof(T) != typeof(SalesOrderHeader)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SalesOrderID", Id);
                return await sqlConnection.QuerySingleOrDefaultAsync<T>(
                    "SELECT * " +
                    "FROM [AdventureWorks2017].[Sales].[SalesOrderHeader] " +
                    "WHERE SalesOrderID=@SalesOrderID",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

        public async override Task<IEnumerable<T>> GetAll<T>()
        {
            if (typeof(T) != typeof(SalesOrderHeader)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * " +
                    "FROM [AdventureWorks2017].[Sales].[SalesOrderHeader]",
                    null,
                    commandType: CommandType.Text);
            }
        }

        public async override Task<IEnumerable<T>> GetRange<T>(int from, int to)
        {
            if (typeof(T) != typeof(SalesOrderHeader)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromSalesOrderID", from);
                dynamicParameters.Add("@ToSalesOrderID", to);
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * " +
                    "FROM [AdventureWorks2017].[Sales].[SalesOrderHeader] " +
                    "WHERE SalesOrderID " +
                    "BETWEEN @FromSalesOrderID AND @ToSalesOrderID",
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
