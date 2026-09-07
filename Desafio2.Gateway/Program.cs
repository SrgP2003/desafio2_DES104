using Ocelot.Cache.CacheManager;
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

builder.Services
    .AddOcelot(builder.Configuration)
    .AddCacheManager(x => x.WithDictionaryHandle());

var app = builder.Build();

await app.UseOcelot();

app.Run();