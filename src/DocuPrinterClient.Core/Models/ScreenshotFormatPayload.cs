using Newtonsoft.Json;

namespace SERGO.DocuPrinter.Client.Core.Models;

[Serializable]
public class ScreenshotFormatPayload
{
    [JsonProperty("type")] public string? Type { get; set; } = "png";
}