using NewronTestOWM.DAL.Entitys;
using NewronTestOWM.DAL.Entitys.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Interface
{
    interface IWeatherGeter
    {
        Task<IEnumerable<WeatherData>> GetWeathersAsync(Location loc, int daysPeriod=5);
    }
}
