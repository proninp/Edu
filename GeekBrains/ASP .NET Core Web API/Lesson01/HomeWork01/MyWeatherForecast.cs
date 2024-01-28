namespace HomeWork01;

public class MyWeatherForecast
{
    private List<WeatherData> _values;

    public MyWeatherForecast()
    {
        _values = new List<WeatherData>();
    }

    public void Add(WeatherData weatherData)
    {
        _values.Add(weatherData);
    }

    public string Get()
    {
        return string.Join(',', _values);
    }

    public List<WeatherData> Values
    {
        get { return _values; }
        set { _values = value; }
    }
}
