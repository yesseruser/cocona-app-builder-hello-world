using Cocona;
using Microsoft.Extensions.DependencyInjection;
using CoconaCliBuilder;
using CoconaCliBuilder.Library.BusinessLogic;

namespace CoconaCliBuilder.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void WriteServiceCalled()
    {
        var builder = CoconaApp.CreateBuilder();

        builder.Services.AddSingleton<IWriteService, MockWriteService>();

        using var app = builder.Build();

        app.Run(() =>
        {
            var writeService = app.Services.GetService<IWriteService>();
            writeService?.Write("Hello, World!");
            Assert.IsTrue((writeService as MockWriteService)?.Written);
        });
    }
}