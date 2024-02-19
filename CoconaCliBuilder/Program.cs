using Cocona;
using Microsoft.Extensions.DependencyInjection;
using CoconaCliBuilder.Library.BusinessLogic;

var builder = CoconaApp.CreateBuilder(args);

builder.Services.AddSingleton<IWriteService, WriteService>();

using var app = builder.Build();

await app.RunAsync(() =>
    app.Services.GetService<IWriteService>()
    ?.Write("Hello, World!"));