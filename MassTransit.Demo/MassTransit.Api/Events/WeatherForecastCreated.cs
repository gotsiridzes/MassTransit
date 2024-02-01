namespace MassTransit.Api.Events;

public record WeatherForecastCreated(DateOnly Date, int TemperatureC, string? Summary);