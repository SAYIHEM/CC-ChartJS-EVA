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
    public class SalesOrderDetailProvider : DataProvider
    {
        public async override Task Delete<T>(int Id)
        {
            throw new NotImplementedException();
        }

        //
        // GET´s BY SalesOrderID, NOT by SalesOrderDetailID !
        //
        public async override Task<T> Get<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public async override Task<IEnumerable<T>> GetOneMultiple<T>(int Id)
        {
            if (typeof(T) != typeof(SalesOrderDetail)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@SalesOrderID", Id);
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Sales].[SalesOrderDetail] WHERE SalesOrderID=@SalesOrderID",
                    dynamicParameters,
                    commandType: CommandType.Text);
            }
        }

        public async override Task<IEnumerable<T>> GetAll<T>()
        {
            if (typeof(T) != typeof(SalesOrderDetail)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Sales].[SalesOrderDetail]",
                    null,
                    commandType: CommandType.Text);
            }
        }
        //
        // GET´s BY SalesOrderID, NOT by SalesOrderDetailID !
        //
        public async override Task<IEnumerable<T>> GetRange<T>(int from, int to)
        {
            if (typeof(T) != typeof(SalesOrderDetail)) throw new InvalidTypeParameterException();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromSalesOrderDetailID", from);
                dynamicParameters.Add("@ToSalesOrderDetailID", to);
                return await sqlConnection.QueryAsync<T>(
                    "SELECT * FROM [AdventureWorks2017].[Sales].[SalesOrderDetail] " +
                    "WHERE SalesOrderID " +
                    "BETWEEN @FromSalesOrderDetailID AND @ToSalesOrderDetailID",
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
