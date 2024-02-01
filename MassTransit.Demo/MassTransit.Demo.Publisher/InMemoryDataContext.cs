using MassTransit.Demo.Publisher.Models;

namespace MassTransit.Demo.Publisher;

public class InMemoryDataContext
{
	private List<WeatherForecast> _data = new();

	public void Create(WeatherForecast model)
	{
		_data.Add(model);
	}

	public List<WeatherForecast> ListWeatherForecasts()
	{
		return _data;
	}
}