using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.DataProvider;
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
            dataProvider = new DataProviderAPI();
        }

        // GET: api/TransactionHistories
        [HttpGet]
        public async Task<IEnumerable<TransactionHistory>> Get()
        {
            return await dataProvider.GetAll<TransactionHistory>();
        }

        // GET: api/TransactionHistories/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<TransactionHistory> Get(int id)
        {
            return await dataProvider.Get<TransactionHistory>(id);
        }
    }
}
