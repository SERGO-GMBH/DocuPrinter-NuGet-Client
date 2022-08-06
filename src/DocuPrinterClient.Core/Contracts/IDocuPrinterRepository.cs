using SERGO.DocuPrinter.Client.Core.Enums;

namespace SERGO.DocuPrinter.Client.Core.Contracts;

public interface IDocuPrinterRepository
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