using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERGO.DocuPrinter.Client.Core.Contracts;
using SERGO.DocuPrinter.Client.Core.Models;
using SERGO.DocuPrinter.Client.Core.Repository;

namespace SERGO.DocuPrinter.Client.DependencyInjection;

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