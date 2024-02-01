using MassTransit;
using MassTransit.Demo.Common.Ext;
using MassTransit.Demo.Publisher;
using MassTransit.Demo.Common.Events;
using MassTransit.Demo.Publisher.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InMemoryDataContext>();
builder.Services.ConfigureMassTransit();
var app = builder.Build();

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (IPublishEndpoint publishEndpoint) =>
{
	var forecast = Enumerable.Range(1, 5)
		.Select(index =>
			new WeatherForecast
			(
				DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				Random.Shared.Next(-20, 55),
				summaries[Random.Shared.Next(summaries.Length)]))
		.ToArray();

	publishEndpoint.PublishBatch(forecast.Select(x => new WeatherForecastCreated(x.Date, x.TemperatureC, x.Summary)));

	return Results.Ok();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();