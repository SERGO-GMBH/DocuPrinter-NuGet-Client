using Newtonsoft.Json;

namespace SERGO.DocuPrinter.Client.Core.Models;

[Serializable]
public class PdfFormatPayload
{
    [JsonProperty("format")]
    public string? Format { get; set; }
}