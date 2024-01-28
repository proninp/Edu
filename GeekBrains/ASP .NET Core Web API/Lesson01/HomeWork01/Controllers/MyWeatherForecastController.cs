using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace HomeWork01.Controllers
{
    [ApiController]
    [Route("myWeatherForecast")]
    public class MyWeatherForecastController : ControllerBase
    {
        private readonly MyWeatherForecast _weatherDataList;

        public MyWeatherForecastController(MyWeatherForecast weatherDataList)
        {
            _weatherDataList = weatherDataList;
        }

        [HttpPost("save")]
        public IActionResult Save([FromQuery] string date, [FromQuery] int? temperatureC)
        {
            _weatherDataList.Add(new WeatherData(date, temperatureC));
            return Ok();
        }

        [HttpPost("modify")]
        public IActionResult Modify([FromQuery] string date, [FromQuery] int newTemperatureC)
        {
            var seekDate = DateOnly.ParseExact(date, "dd.MM.yyyy");
            for (int i = 0; i < _weatherDataList.Values.Count; i++)
            {
                if (seekDate == _weatherDataList.Values[i].Date)
                {
                    _weatherDataList.Values[i].TemperatureC = newTemperatureC;
                }
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string date)
        {
            var seekDate = DateOnly.ParseExact(date, "dd.MM.yyyy");
            for (int i = 0; i < _weatherDataList.Values.Count; i++)
            {
                if (seekDate == _weatherDataList.Values[i].Date)
                {
                    _weatherDataList.Values.RemoveAt(i);
                }    
            }
            return Ok();
        }

        [HttpGet(Name = "GetMyWeatherForecast")]
        public IEnumerable<WeatherData> Get()
        {
            return _weatherDataList.Values;
        }

        //[HttpGet(Name = "GetMyWeatherForecastRange")]
        //public IEnumerable<WeatherData> GetRange([FromQuery] string date)
        //{
            
        //}
    }
}
