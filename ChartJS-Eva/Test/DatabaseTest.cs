using ChartJS_Eva.DataProvider;
using ChartJS_Eva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChartJS_Eva.Test
{
    public class DatabaseTest
    {
        static void Main(string[] args)
        {
            DataProviderAPI db_api = new DataProviderAPI();
            Task t = db_api.Get<TransactionHistory>(10);
            t.Start();

            //TransactionHistory trans_history = t.;

            //int result = Convert.ToInt32(task.Result);
        }
    }
}