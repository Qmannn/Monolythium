using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monolythium;

var hostBuilder = Host.CreateDefaultBuilder();

hostBuilder.ConfigureServices(services => {
    services.AddApplicationRoot();
    services.AddHostedService<OrderTestHostedService>();
});

var app = hostBuilder.Build();

app.Run();