using ExportHtmlClient.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERGO.Bedrockio.HtmlExportClient.Core.Contracts;
using SERGO.Bedrockio.HtmlExportClient.Core.Repository;

namespace SERGO.Bedrockio.ExportHtmlClient.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddExportHtmlClient(this IServiceCollection services, IConfigurationSection section)
    {
        var config = section.Get<ExportHtmlClientOptions>();

        services.AddHttpClient<IHtmlExportRepository, HtmlExportRepository>(client =>
        {
            client.BaseAddress = new Uri(config.BaseUrl!);
            client.Timeout = TimeSpan.FromSeconds(config.TimeOut);
        });

        return services;
    }
    
    public static IServiceCollection AddExportHtmlClient(this IServiceCollection services, Action<ExportHtmlClientOptions> builder)
    {
        var config = new ExportHtmlClientOptions();
        builder(config);        

        services.AddHttpClient<IHtmlExportRepository, HtmlExportRepository>(client =>
        {
            client.BaseAddress = new Uri(config.BaseUrl!);
            client.Timeout = TimeSpan.FromSeconds(config.TimeOut);
        });

        return services;
    }
}