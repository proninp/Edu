namespace HomeWork01
{
    public class WeatherData
    {
        public DateOnly Date { get; set; }

        public int? TemperatureC { get; set; }

        public int? TemperatureF => (TemperatureC is null) ? null : 32 + (int)(TemperatureC / 0.5556);

        public WeatherData(string date, int? temperatureC)
        {
            Date = GetDateOnly(date);
            TemperatureC = temperatureC;
        }

        public static DateOnly GetDateOnly(string date) => DateOnly.ParseExact(date, "dd.MM.yyyy");

        public override string ToString()
        {
            return $"Date: {Date.ToShortDateString()}; Temperare in Celsium: {TemperatureC}";
        }
    }
}
