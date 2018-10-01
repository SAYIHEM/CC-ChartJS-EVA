using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Setup
{
    public static class Config
    {
        public static string ConnectionString { get; } = "Server=localhost\\SQLEXPRESS;Database=AdventureWorks2017;Trusted_Connection=True;";

    }
}
