using Newtonsoft.Json;

namespace SERGO.Bedrockio.HtmlExportClient.Core.Models;

[Serializable]
public class PdfFormatPayload
{
    [JsonProperty("format")]
    public string? Format { get; set; }
}