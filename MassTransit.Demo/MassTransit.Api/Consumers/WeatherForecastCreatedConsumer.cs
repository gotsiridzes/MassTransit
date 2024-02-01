using MassTransit.Api.Events;

namespace MassTransit.Api.Consumers;

// ReSharper disable once ClassNeverInstantiated.Global
public class WeatherForecastCreatedConsumer(InMemoryDataContext dataContext) : IConsumer<WeatherForecastCreated>
{
	public async Task Consume(ConsumeContext<WeatherForecastCreated> context)
	{
		dataContext.Create(context.Message.MapToDbModel());
	}
}