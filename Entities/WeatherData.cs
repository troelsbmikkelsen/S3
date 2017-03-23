using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities
{
    public class WeatherData
    {
        public string City { get; }

        public string Temperature { get; }

        public WeatherData(string city, string temperature) {
            City = city;
            Temperature = temperature;
        }
    }
}
