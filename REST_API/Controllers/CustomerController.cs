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
    public class CustomerController : ControllerBase
    {
        private IDataProvider dataProvider;

        public CustomerController()
        {
            // TODO: Fix inheritance structure of DataProvider
            dataProvider = new DataProviderAPI();
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await dataProvider.GetAll<Customer>();
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<Customer> Get(int id)
        {
            return await dataProvider.Get<Customer>(id);
        }

        // GET: api/Customer/5-10
        [HttpGet("{from}-{to}", Name = "GetRangeCustomer")]
        public async Task<IEnumerable<Customer>> Get(int from, int to)
        {
            return await dataProvider.GetRange<Customer>(from, to);
        }
    }
}
