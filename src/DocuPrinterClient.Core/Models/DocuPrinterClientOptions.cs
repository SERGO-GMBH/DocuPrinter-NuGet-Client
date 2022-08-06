namespace SERGO.DocuPrinter.Client.Core.Models;

[Serializable]
public class DocuPrinterClientOptions
{
    public string? BaseUrl { get; set; }
    public int TimeOut { get; set; }
}