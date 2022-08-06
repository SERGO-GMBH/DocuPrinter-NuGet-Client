using System.Text;
using Newtonsoft.Json;
using SERGO.DocuPrinter.Client.Core.Constants;
using SERGO.DocuPrinter.Client.Core.Contracts;
using SERGO.DocuPrinter.Client.Core.Enums;
using SERGO.DocuPrinter.Client.Core.Exceptions;
using SERGO.DocuPrinter.Client.Core.Models;
using SERGO.DocuPrinter.Client.Core.Utils;

namespace SERGO.DocuPrinter.Client.Core.Repository;

public class HtmlExportRepository : IHtmlExportRepository
{
    private readonly HttpClient _httpClient;

    public HtmlExportRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Stream> ToPdfFromHtml(string html,
        bool convertToBase64 = false,
        PdfFormats formats = PdfFormats.Letter)
    {
        var content = ConvertToBase64(html, convertToBase64);
        
        var payload = new PdfPayload
        {
            Html = content,
            Base64 = convertToBase64,
            Export = new PdfFormatPayload
            {
                Format = formats.ToString()
            }
        };  
        
        var json = JsonConvert.SerializeObject(payload);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ExportHtmlEndpointConstants.Pdf, data);

        if (!response.IsSuccessStatusCode)
        {
            throw new ExportHtmlClientException(
                await response.Content.ReadAsStringAsync()
            );
        }
        
        var responseContent = response.Content;
        return await responseContent.ReadAsStreamAsync();
    }

    public async Task<Stream> ToScreenshotFromHtml(string html, bool convertToBase64 = false, PdfFormats formats = PdfFormats.Letter)
    {
        var content = ConvertToBase64(html, convertToBase64);
        
        var payload = new ScreenshotPayload
        {
            Html = content
        };  
        
        var json = JsonConvert.SerializeObject(payload);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ExportHtmlEndpointConstants.Screenshot, data);

        if (!response.IsSuccessStatusCode)
        {
            throw new ExportHtmlClientException(
                await response.Content.ReadAsStringAsync()
            );
        }
        
        var responseContent = response.Content;
        return await responseContent.ReadAsStreamAsync();
    }

    private static string ConvertToBase64(string html, bool convert)
    {
        return convert ? ExportHtmlBase64Utils.Base64Encode(html) : html;
    }
}