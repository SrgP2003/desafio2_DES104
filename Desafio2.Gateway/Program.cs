using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var ocelotConfig = builder.Environment.IsEnvironment("Docker")
    ? "ocelot.Docker.json"
    : "ocelot.json";

builder.Configuration.AddJsonFile(
    ocelotConfig,
    optional: false,
    reloadOnChange: true
);

builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();