using Newtonsoft.Json;

namespace SERGO.Bedrockio.HtmlExportClient.Core.Models;

[Serializable]
public class ScreenshotPayload
{
    [JsonProperty("html")] public string? Html { get; set; }
    [JsonProperty("export")] public ScreenshotFormatPayload Export { get; set; } = new();
}