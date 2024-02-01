using MassTransit.Demo.Common.Events;
using MassTransit.Demo.Publisher.Models;

namespace MassTransit.Demo.Publisher;

public static class Ext
{
	public static WeatherForecast MapToDbModel(this WeatherForecastCreated weatherForecastEvt)
	{
		return new WeatherForecast(
			weatherForecastEvt.Date,
			weatherForecastEvt.TemperatureC,
			weatherForecastEvt.Summary);
	}
}