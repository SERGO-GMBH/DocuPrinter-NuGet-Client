using Microsoft.Extensions.DependencyInjection;
using SERGO.Bedrockio.ExportHtmlClient.DependencyInjection;
using SERGO.Bedrockio.HtmlExportClient.Core.Contracts;
using Xunit;

namespace ExportHtmlClient.Tests.Core;

public class HtmlExportRepositoryTests
{
    [Fact]
    public void ShouldCorrectlyConvertFromHtmlToPdf()
    {
        var services = new ServiceCollection();
        services.AddExportHtmlClient(configure =>
        {
            configure.BaseUrl = "";
            configure.TimeOut = 10000;
        });
        var provider = services.BuildServiceProvider();

        var client = provider.GetRequiredService<IHtmlExportRepository>();
        client.ToPdfFromHtml("<p>Hallo ich bin ein Text und möchte getestet werden </p>").Wait();
    }
    
    [Fact]
    public void ShouldCorrectlyConvertFromHtmlToScreenshot()
    {
        var services = new ServiceCollection();
        services.AddExportHtmlClient(configure =>
        {
            configure.BaseUrl = "";
            configure.TimeOut = 10000;
        });
        var provider = services.BuildServiceProvider();

        var client = provider.GetRequiredService<IHtmlExportRepository>();
        client.ToScreenshotFromHtml("<p>Hallo ich bin ein Text und möchte getestet werden </p>").Wait();
    }
    
}