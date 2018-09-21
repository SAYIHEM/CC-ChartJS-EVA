using ChartJS_Eva.DataProvider;
using ChartJS_Eva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChartJS_Eva.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {

        public IDataProvider dataProvider;

        public MainController(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionHistory>> Get()
        {
            return await dataProvider.GetAll<TransactionHistory>();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<TransactionHistory> Get(int id)
        {
            return await dataProvider.Get<TransactionHistory>(id);
        }

        [HttpPost]
        public async Task Post([System.Web.Http.FromBody]TransactionHistory model)
        {
            await dataProvider.Insert<TransactionHistory>(model);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task Put(int id, [System.Web.Http.FromBody]TransactionHistory model)
        {
            await dataProvider.Modify<TransactionHistory>(model);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            await dataProvider.Delete<TransactionHistory>(id);
        }

    }
}