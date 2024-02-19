using Cocona;
using Microsoft.Extensions.DependencyInjection;
using CoconaCliBuilder.Library.BusinessLogic;
using CoconaCliBuilder.Library.Models;

var builder = CoconaApp.CreateBuilder(args);

builder.Services.AddSingleton<IWriteService, WriteService>();
builder.Services.AddSingleton<ILocaliser, Localiser>();

using var app = builder.Build();

await app.RunAsync(() =>
{
    var localiser = app.Services.GetService<ILocaliser>()!;
    var writeService = app.Services.GetService<IWriteService>()!;
    
    var langName = localiser.GetCurrentLanguageName();
    var message = localiser.GetLocalizedString(StringKeys.Hello, langName,
        (key, _, _) => localiser.GetLocalizedString(key, localiser.GetDefaultLanguageName()));
    writeService.WriteLine(message);
});