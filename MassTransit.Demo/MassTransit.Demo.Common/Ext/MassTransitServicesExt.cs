using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Demo.Common.Ext;

public static class MassTransitServicesExt
{
	public static IServiceCollection ConfigureMassTransit(this IServiceCollection services)
	{
		return services.AddMassTransit(config =>
		{
			config.SetKebabCaseEndpointNameFormatter();
			
			var allTypes = AppDomain.CurrentDomain
				.GetAssemblies()
				.Where(x => x.FullName!.Contains("MassTransit.Demo"))
				.SelectMany(x => x.GetTypes())
				.ToList();

			var allConsumers = allTypes
				.Where(x => x.GetInterfaces().Any(typeof(IConsumer<>).IsAssignableTo))
				.ToArray();

			config.AddConsumers(allConsumers);

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
	}
}