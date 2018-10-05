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
        private IDataProvider dataProvider;

        public SalesOrderDetailController()
        {
            // TODO: Fix inheritance structure of DataProvider
            dataProvider = new DataProviderAPI();
        }

        // GET: api/SalesOrderDetail
        [HttpGet]
        public async Task<IEnumerable<SalesOrderDetail>> Get()
        {
            return await dataProvider.GetAll<SalesOrderDetail>();
        }

        // GET: api/SalesOrderDetail/5
        [HttpGet("{id}", Name = "GetSalesOrderDetail")]
        public async Task<SalesOrderDetail> Get(int id)
        {
            return await dataProvider.Get<SalesOrderDetail>(id);
        }

        // GET: api/SalesOrderDetail/5-10
        [HttpGet("{from}-{to}", Name = "GetRangeSalesOrderDetail")]
        public async Task<IEnumerable<SalesOrderDetail>> Get(int from, int to)
        {
            return await dataProvider.GetRange<SalesOrderDetail>(from, to);
        }
    }
}
