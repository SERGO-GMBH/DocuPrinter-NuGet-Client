using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SERGO.DocuPrinter.Client.Core.Contracts;
using SERGO.DocuPrinter.Client.Core.Models;
using SERGO.DocuPrinter.Client.Core.Repository;

namespace SERGO.DocuPrinter.Client.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDocuPrinterClient(this IServiceCollection services, IConfigurationSection section)
    {
        var config = section.Get<DocuPrinterClientOptions>();

        services.AddHttpClient<IDocuPrinterRepository, DocuPrinterRepository>(client =>
        {
            client.BaseAddress = new Uri(config.BaseUrl!);
            client.Timeout = TimeSpan.FromSeconds(config.TimeOut);
        });

        return services;
    }
    
    public static IServiceCollection AddDocuPrinterClient(this IServiceCollection services, Action<DocuPrinterClientOptions> builder)
    {
        var config = new DocuPrinterClientOptions();
        builder(config);        

        services.AddHttpClient<IDocuPrinterRepository, DocuPrinterRepository>(client =>
        {
            client.BaseAddress = new Uri(config.BaseUrl!);
            client.Timeout = TimeSpan.FromSeconds(config.TimeOut);
        });

        return services;
    }
}