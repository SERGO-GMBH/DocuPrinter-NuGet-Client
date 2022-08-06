using Newtonsoft.Json;

namespace SERGO.DocuPrinter.Client.Core.Models;

[Serializable]
public class ScreenshotPayload
{
    [JsonProperty("html")] public string? Html { get; set; }
    [JsonProperty("export")] public ScreenshotFormatPayload Export { get; set; } = new();
}