using MassTransit;
using MassTransit.Demo.Common.Ext;
using MassTransit.Demo.Consumer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.ConfigureMassTransit();

var host = builder.Build();
host.Run();
