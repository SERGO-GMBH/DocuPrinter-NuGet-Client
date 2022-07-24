using Newtonsoft.Json;

namespace SERGO.Bedrockio.HtmlExportClient.Core.Models;

[Serializable]
public class ScreenshotFormatPayload
{
    [JsonProperty("type")] public string? Type { get; set; } = "png";
}