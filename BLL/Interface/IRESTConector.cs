using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Interface
{
    internal interface IRESTConector
    {
        Task<IEnumerable<T>> GetListAsync<T>(string url, string paramtr, IDictionary<string, string> header);
        Task<T> GetAsync<T>(string url, string paramtr, IDictionary<string, string> header);
    }
}
