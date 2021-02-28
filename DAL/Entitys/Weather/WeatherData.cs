using NewronTestOWM.DAL.Helper.Atributes;
using Newtonsoft.Json;
using System;

namespace NewronTestOWM.DAL.Entitys.Weather
{
    class WeatherData
    {
        [JsonConverter(typeof(UTCDateTimeConverter))]
        [JsonProperty("ts")]
        public DateTime DateTime { get; set; }
        [JsonProperty("low_temp")]
        public double LowTemp { get; set; }
        [JsonProperty("max_temp")]
        public double MaxTemp { get; set; }
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("pres")]
        public double Pres { get; set; }
    }
}
