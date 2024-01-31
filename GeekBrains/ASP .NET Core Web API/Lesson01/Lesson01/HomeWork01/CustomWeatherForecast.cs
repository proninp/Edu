namespace HomeWork01;

public class CustomWeatherForecast
{
    private List<WeatherData> _values;

    public CustomWeatherForecast()
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

    public IEnumerable<WeatherData> GetRange(string fromDate, string toDate)
    {
        DateOnly startDate = WeatherData.GetDateOnly(fromDate);
        DateOnly endDate = WeatherData.GetDateOnly(toDate);
        return _values.Where(x => x.Date >= startDate && x.Date <= endDate).ToList();
    }

    public void ReplaceTemperature(string date, int newTemperatureC)
    {
        var seekDate = WeatherData.GetDateOnly(date);
        for (int i = 0; i < _values.Count; i++)
        {
            if (seekDate == _values[i].Date)
                _values[i].TemperatureC = newTemperatureC;
        }
    }

    public void Remove(string date)
    {
        var seekDate = WeatherData.GetDateOnly(date);
        for (int i = 0; i < _values.Count; i++)
        {
            if (seekDate == _values[i].Date)
                _values.RemoveAt(i);
        }
    }

    public List<WeatherData> Values
    {
        get { return _values; }
        set { _values = value; }
    }
}
