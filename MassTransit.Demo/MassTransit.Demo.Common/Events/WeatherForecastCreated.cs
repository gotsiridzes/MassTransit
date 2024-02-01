using System;

namespace MassTransit.Demo.Common.Events;

public record WeatherForecastCreated(DateOnly Date, int TemperatureC, string? Summary);