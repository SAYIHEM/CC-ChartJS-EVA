using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartJS_Eva.DataProvider
{
    public class SingleDataProvider : DataProvider
    {
        private Type providedType; 

        protected Type GetProvidedType()
        {
            return providedType;
        }
    }
}