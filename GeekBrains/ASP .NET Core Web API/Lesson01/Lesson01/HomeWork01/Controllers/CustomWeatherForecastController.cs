using Microsoft.AspNetCore.Mvc;

namespace HomeWork01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomWeatherForecastController : ControllerBase
    {
        private readonly CustomWeatherForecast _weatherDataList;

        public CustomWeatherForecastController(CustomWeatherForecast weatherDataList)
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
            _weatherDataList.ReplaceTemperature(date, newTemperatureC);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string date)
        {
            _weatherDataList.Remove(date);
            return Ok();
        }

        [HttpGet(Name = "read")]
        public IEnumerable<WeatherData> Get()
        {
            return _weatherDataList.Values;
        }

        [HttpGet("readRange", Name = "readRange")]
        public IEnumerable<WeatherData> GetRange([FromQuery] string fromDate, string toDate)
        {
            return _weatherDataList.GetRange(fromDate, toDate);
        }
    }
}
