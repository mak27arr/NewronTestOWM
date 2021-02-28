using NewronTestOWM.BLL.Interface;
using NewronTestOWM.DAL.Entitys;
using NewronTestOWM.DAL.Entitys.Weather;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace NewronTestOWM.BLL.Module.WetherAPI
{
    class WeatherBitWeatherGeter : IWeatherGeter
    {
        private string api_key;
        IRESTConector rESTC;
        public WeatherBitWeatherGeter(IRESTConector rESTConector, string api_token)
        {
            api_key = api_token;
            rESTC = rESTConector;
        }
        public async Task<IEnumerable<WeatherData>> GetWeathersAsync(Location loc,int daysPeriod=16)
        {
            string url = "https://api.weatherbit.io";
            string param = "/v2.0/forecast/daily?lat=" + loc.Latitude.ToString(CultureInfo.InvariantCulture) + "&lon=" + loc.Longitude.ToString(CultureInfo.InvariantCulture) + "&days="+daysPeriod+"&key=" + api_key;
            
            var data =  await rESTC.GetAsync<ServerData>(url, param, null);
            if (data != null)
            {
                return data.data;
            }
            else
            {
                return new List<WeatherData>();
            }
        }

        private class ServerData
        {
            public string city_name;
            public string lon;
            public string timezone;
            public string lat;
            public string country_code;
            public string state_code;
            public List<WeatherData> data; 
        };
    }
}
