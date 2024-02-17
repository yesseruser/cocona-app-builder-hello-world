using Cocona;
using Microsoft.Extensions.DependencyInjection;

using CoconaCliBuilder;

var builder = CoconaApp.CreateBuilder(args);

builder.Services.AddSingleton<IWriteService, WriteService>();

using var app = builder.Build();

await app.RunAsync(() =>
    app.Services.GetService<IWriteService>()
    ?.Write("Hello, World!"));