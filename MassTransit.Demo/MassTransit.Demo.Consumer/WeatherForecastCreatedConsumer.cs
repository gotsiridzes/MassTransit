using MassTransit.Demo.Common.Events;

namespace MassTransit.Demo.Consumer;

// ReSharper disable once ClassNeverInstantiated.Global
public class WeatherForecastCreatedConsumer(/*InMemoryDataContext dataContext*/) : IConsumer<WeatherForecastCreated>
{
	public async Task Consume(ConsumeContext<WeatherForecastCreated> context)
	{
		Console.WriteLine("Received RabbitMq Event.");
		//dataContext.Create(context.Message.MapToDbModel());
	}
}