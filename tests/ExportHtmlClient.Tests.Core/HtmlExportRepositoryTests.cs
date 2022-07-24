using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERGO.Bedrockio.ExportHtmlClient.DependencyInjection;
using SERGO.Bedrockio.HtmlExportClient.Core.Contracts;
using Xunit;

namespace SERGO.Bedrockio.ExportHtmlClient.Tests.Core;

public class HtmlExportRepositoryTests
{
    private IServiceProvider _provider;
    
    public HtmlExportRepositoryTests()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        var section = configuration.GetSection("exporthtml");
        
        services.AddExportHtmlClient(section);

        _provider = services.BuildServiceProvider();
    }
    
    [Fact]
    public void ShouldCorrectlyConvertFromHtmlToPdf()
    {
        var client = _provider.GetRequiredService<IHtmlExportRepository>();
        client.ToPdfFromHtml("<p>Hallo ich bin ein Text und möchte getestet werden </p>").Wait();
    }
    
    [Fact]
    public void ShouldCorrectlyConvertFromHtmlToScreenshot()
    {
        var client = _provider.GetRequiredService<IHtmlExportRepository>();
        client.ToScreenshotFromHtml("<p>Hallo ich bin ein Text und möchte getestet werden </p>").Wait();
    }
    
}