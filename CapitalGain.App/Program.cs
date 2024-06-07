using CapitalGain.App;
using CapitalGain.App.Abstractions;
using CapitalGain.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using System.Text.Json;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

JsonSerializerOptions JsonOptions = new()
{
    WriteIndented = true,
    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
};

builder.Services.AddSingleton<ITransactionService, TransactionService>();
builder.Services.AddSingleton<App>();
builder.Services.AddSingleton(JsonOptions);

using IHost host = builder.Build();
await host.StartAsync();

var app = host.Services.GetService<App>();
app!.Execute();

await host.StopAsync();