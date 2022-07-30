using learn.core.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Waed_FinalTask_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        List<string> Jo = new List<string>();
        public WeatherApiController( )
        {
            Jo.Add("Amman");
            Jo.Add("Irbid");
            Jo.Add("Aqaba");
            Jo.Add("Madaba");
            Jo.Add("Ajloun");
            Jo.Add("Karak");
            Jo.Add("Zarka");
            Jo.Add("Jerash");
            Jo.Add("mafraq");
        }
 
        [HttpPost("weather/{city?}")]
        public String WeatherDetail(string? City)
        {

            string appId = "55bbe76c3dd83bfa7da364f69c92a8d1";

            List<object> w = new List<object>();
            if (City == null)
            {

                for (int i = 0; i < Jo.Count; i++)
                {


                    string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", Jo[i], appId);

                    using (WebClient client = new WebClient())
                    {
                        string json = client.DownloadString(url);



                        RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);


                        ResultViewModel rslt = new ResultViewModel();

                        rslt.Country = weatherInfo.sys.country;
                        rslt.City = weatherInfo.name;
                        rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                        rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                        rslt.Description = weatherInfo.weather[0].description;
                        rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                        rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                        rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                        rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                        rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);

                        w.Add(rslt);
                    }
                }


                return JsonConvert.SerializeObject(w);
            }
            else
            {

                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);



                    RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);
                    ResultViewModel rslt = new ResultViewModel();

                    rslt.Country = weatherInfo.sys.country;
                    rslt.City = weatherInfo.name;
                    rslt.Lat = Convert.ToString(weatherInfo.coord.lat);
                    rslt.Lon = Convert.ToString(weatherInfo.coord.lon);
                    rslt.Description = weatherInfo.weather[0].description;
                    rslt.Humidity = Convert.ToString(weatherInfo.main.humidity);
                    rslt.Temp = Convert.ToString(weatherInfo.main.temp);
                    rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like);
                    rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max);
                    rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min);


                    return new JavaScriptSerializer().Serialize(rslt);

                }
            }










        }

    }
}
