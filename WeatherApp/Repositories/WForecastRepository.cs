using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.openweathermapModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WeatherApp.Repositories
{
    public class WForecastRepository : IWeatherRepository
    {
        public WeatherResponse GetForecast(string city)
        {
            string App_Id = Config.Values.APP_ID;
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={App_Id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                return content?.ToObject<WeatherResponse>();
            }
            else
            {
                return null;
            }
        }
    }
}
