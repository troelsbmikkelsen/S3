using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Weather.Entities;

namespace Weather.Services
{
    public class Client
    {
        string apiKey = "818105d2f232ae11a90fe3f295d523cc";
        //string apiKey = "b1b15e88fa797225412429c1c50c122a1";
        string formatMode = "xml";
        // // // // // //
        // // // // // //
        // Change from sample to api
        string serverUrl = "http://api.openweathermap.org/data/2.5/";
        HttpClient client;

        public Task<WeatherData> GetCurrentTemperature(string city) {
            return new Task<WeatherData>( () => CallWeatherApi(city).Result );
        }

        public async Task<WeatherData> CallWeatherApi(string city) {
            WeatherData wd = new WeatherData(city, "error");

            client = new HttpClient();

            client.BaseAddress = new Uri(serverUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));

            try {
                HttpResponseMessage response = await client.GetAsync($"weather?q={city}&mode={formatMode}&units=metric&appid={apiKey}");

                if (response.IsSuccessStatusCode) {
                    string data = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(data);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    XmlNode temp = doc.SelectSingleNode("//temperature");
                    Debug.WriteLine(temp.Attributes["value"].InnerText);

                    XmlNode cityName = doc.SelectSingleNode("//city");

                    wd = new WeatherData(cityName.Attributes["name"].InnerText, temp.Attributes["value"].InnerText);
                }
            } catch(Exception e) {
                Debug.WriteLine(e.ToString());
            }

            return wd;
        }
    }
}
