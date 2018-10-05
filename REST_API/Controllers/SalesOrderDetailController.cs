using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.DataProviders;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderDetailController : ControllerBase
    {
        private IDataProvider SalesOrderDetailProvider;

        public SalesOrderDetailController()
        {
            // TODO: Fix inheritance structure of DataProvider
            SalesOrderDetailProvider = new DataProviderAPI();
        }

        // GET: api/SalesOrderDetail
        [HttpGet]
        public async Task<IEnumerable<SalesOrderDetail>> Get()
        {
            return await SalesOrderDetailProvider.GetAll<SalesOrderDetail>();
        }

        // GET: api/SalesOrderDetail/5
        [HttpGet("{id}", Name = "GetSalesOrderDetail")]
        public async Task<IEnumerable<SalesOrderDetail>> Get(int id)
        {
            return await SalesOrderDetailProvider.GetOneMultiple<SalesOrderDetail>(id);
        }

        // GET: api/SalesOrderDetail/5-10
        [HttpGet("{from}-{to}", Name = "GetRangeSalesOrderDetail")]
        public async Task<IEnumerable<SalesOrderDetail>> Get(int from, int to)
        {
            return await SalesOrderDetailProvider.GetRange<SalesOrderDetail>(from, to);
        }
    }
}
