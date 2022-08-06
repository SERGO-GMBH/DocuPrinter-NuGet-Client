using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERGO.DocuPrinter.Client.Core.Contracts;
using SERGO.DocuPrinter.Client.DependencyInjection;
using Xunit;

namespace SERGO.DocuPrinter.Client.Tests.Core;

public class DocuPrinterRepositoryTests
{
    private readonly IServiceProvider _provider;
    
    public DocuPrinterRepositoryTests()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        var section = configuration.GetSection("DocuPrinter");
        
        services.AddDocuPrinterClient(section);

        _provider = services.BuildServiceProvider();
    }
    
    [Fact]
    public void ShouldCorrectlyConvertFromHtmlToPdf()
    {
        var client = _provider.GetRequiredService<IDocuPrinterRepository>();
        client.ToPdfFromHtmlAsync("<p>Hallo ich bin ein Text und möchte getestet werden </p>").Wait();
    }
    
    [Fact]
    public void ShouldCorrectlyConvertFromHtmlToScreenshot()
    {
        var client = _provider.GetRequiredService<IDocuPrinterRepository>();
        client.ToScreenshotFromHtmlAsync("<p>Hallo ich bin ein Text und möchte getestet werden </p>").Wait();
    }
}