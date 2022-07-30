using System;
using System.Collections.Generic;
using System.Text;

namespace learn.core.Data
{
   public class ResultViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Description { get; set; }
        public string Humidity { get; set; }
        public string TempFeelsLike { get; set; }
        public string Temp { get; set; }
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        public string WeatherIcon { get; set; }
    }

}
