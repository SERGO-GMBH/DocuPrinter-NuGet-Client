using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SERGO.Bedrockio.HtmlExportClient.Core.Models;

[Serializable]
public class PdfPayload
{
    [JsonProperty("html")]
    public string? Html { get; set; }
    [JsonProperty("export")]
    public PdfFormatPayload? Export { get; set; }
    [JsonProperty("base64")] public bool Base64 { get; set; }
}