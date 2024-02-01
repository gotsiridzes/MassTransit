using MassTransit.Api.Events;

namespace MassTransit.Api;

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