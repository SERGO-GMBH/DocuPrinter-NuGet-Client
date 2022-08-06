namespace SERGO.DocuPrinter.Client.Core.Utils;

public class ExportHtmlBase64Utils
{
    public static string Base64Encode(string plainText) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }
}