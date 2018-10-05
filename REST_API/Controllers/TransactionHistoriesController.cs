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
    public class TransactionHistoriesController : ControllerBase
    {
        private IDataProvider dataProvider;

        public TransactionHistoriesController()
        {
            // TODO: Fix inheritance structure of DataProvider
            dataProvider = new DataProviderAPI();
        }

        // GET: api/TransactionHistories
        [HttpGet]
        public async Task<IEnumerable<TransactionHistory>> Get()
        {
            return await dataProvider.GetAll<TransactionHistory>();
        }

        // GET: api/TransactionHistories/5
        [HttpGet("{id}", Name = "GetTransactionHistory")]
        public async Task<TransactionHistory> Get(int id)
        {
            return await dataProvider.Get<TransactionHistory>(id);
        }

        // GET: api/TransactionHistories/5-10
        [HttpGet("{from}-{to}", Name = "GetRangeTransactionHistory")]
        public async Task<IEnumerable<TransactionHistory>> Get(int from, int to)
        {
            return await dataProvider.GetRange<TransactionHistory>(from, to);
        }
    }
}
