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
    public class SalesOrderHeaderController : ControllerBase
    {
        private IDataProvider dataProvider;

        public SalesOrderHeaderController()
        {
            // TODO: Fix inheritance structure of DataProvider
            dataProvider = new DataProviderAPI();
        }

        // GET: api/SalesOrderHeader
        [HttpGet]
        public async Task<IEnumerable<SalesOrderHeader>> Get()
        {
            return await dataProvider.GetAll<SalesOrderHeader>();
        }

        // GET: api/SalesOrderHeader/5
        [HttpGet("{id}", Name = "GetSalesOrderHeader")]
        public async Task<SalesOrderHeader> Get(int id)
        {
            return await dataProvider.Get<SalesOrderHeader>(id);
        }

        // GET: api/SalesOrderHeader/5-10
        [HttpGet("{from}-{to}", Name = "GetRangeSalesOrderHeader")]
        public async Task<IEnumerable<SalesOrderHeader>> Get(int from, int to)
        {
            return await dataProvider.GetRange<SalesOrderHeader>(from, to);
        }
    }
}
