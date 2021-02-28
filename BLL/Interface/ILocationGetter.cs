using NewronTestOWM.DAL.Entitys;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Interface
{
    internal interface ILocationGetter
    {
        Task<Location> GetMyLocationAsync();
    }
}
