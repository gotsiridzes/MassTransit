namespace MassTransit.Api.Consumers
{
    public class WeatherForecastCreatedConsumer : IConsumer<WeatherForecastCreated>
    {
        private readonly InMemoryDataContext _dataContext;

        public WeatherForecastCreatedConsumer(InMemoryDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Consume(ConsumeContext<WeatherForecastCreated> context)
        {
            _dataContext.Create(context.Message.MapToDbModel());
        }
    }
}
