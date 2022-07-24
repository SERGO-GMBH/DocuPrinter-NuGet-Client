namespace ExportHtmlClient.Core.Models;

[Serializable]
public class ExportHtmlClientOptions
{
    public string? BaseUrl { get; set; }
    public int TimeOut { get; set; }

}