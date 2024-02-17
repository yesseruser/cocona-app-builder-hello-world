using Cocona;
using Microsoft.Extensions.DependencyInjection;

using CoconaCliBuilder;

var builder = CoconaApp.CreateBuilder(args);

builder.Services.AddSingleton<IPrintService, PrintService>();

using var app = builder.Build();

await app.RunAsync(() =>
{
    app.Services.GetService<IPrintService>()
        ?.Print("Hello, World!");
});