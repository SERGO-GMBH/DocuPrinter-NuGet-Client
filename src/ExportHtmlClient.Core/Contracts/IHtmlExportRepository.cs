using SERGO.Bedrockio.HtmlExportClient.Core.Enums;

namespace SERGO.Bedrockio.HtmlExportClient.Core.Contracts;

public interface IHtmlExportRepository
{
    Task<Stream> ToPdfFromHtml(
        string html, 
        bool convertToBase64 = false,
        PdfFormats formats = PdfFormats.Letter);
    
    Task<Stream> ToScreenshotFromHtml(
        string html, 
        bool convertToBase64 = false,
        PdfFormats formats = PdfFormats.Letter);
    
}