namespace SERGO.Bedrockio.HtmlExportClient.Core.Exceptions;

public class ExportHtmlClientException : Exception
{
    public ExportHtmlClientException()
    {
        
    }
    
    public ExportHtmlClientException(string message) : base(message)
    {
        
    }

    public ExportHtmlClientException(string message, Exception innerException) : base(message, innerException)
    {
            
    }
}