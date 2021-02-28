using System.Net;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Interface
{
    interface IIPHelper
    {
        Task<string> GetMyPublicIPStringAsync();
        Task<IPAddress> GetMyPublicIPAsync();
    }
}
