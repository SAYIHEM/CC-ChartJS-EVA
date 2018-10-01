using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API.DataProvider
{
    public interface IDataProvider
    {

        Task<IEnumerable<T>> GetAll<T>() where T : Model;

        Task<T> Get<T>(int Id) where T : Model;

        Task Insert<T>(T model) where T : Model;

        Task Modify<T>(T model) where T : Model;

        Task Delete<T>(int Id) where T : Model;
    }
}
