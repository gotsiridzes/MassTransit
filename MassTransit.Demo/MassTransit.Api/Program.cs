using MassTransit;
using MassTransit.Api;
using MassTransit.Api.Consumers;
using MassTransit.Api.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InMemoryDataContext>();
builder.Services.AddMassTransit(config =>
{
	config.SetKebabCaseEndpointNameFormatter();
	config.AddConsumer<WeatherForecastCreatedConsumer>();

	config.UsingRabbitMq((context, configurator) =>
	{
		configurator.Host("localhost", "/", h =>
		{
			h.Username("guest");
			h.Password("guest");
		});

		configurator.ConfigureEndpoints(context);
	});
});

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

	//var first = forecast.First();
	//publishEndpoint.Publish(new WeatherForecastCreated(
	//			Guid.NewGuid(),
	//			first.Date,
	//			first.TemperatureC,
	//			first.Summary));

	return Results.Accepted();
})
.WithName("GetWeatherForecast")
.WithOpenApi();

//app.MapGet("/weatherforecast", (InMemoryDataContext data) => data.ListWeatherForecasts())
//.WithName("ListWeatherForecast")
//.WithOpenApi();

app.Run();