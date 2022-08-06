namespace SERGO.DocuPrinter.Client.Core.Exceptions;

public class DocuPrinterClientException : Exception
{
    public DocuPrinterClientException()
    {
        
    }
    
    public DocuPrinterClientException(string message) : base(message)
    {
        
    }

    public DocuPrinterClientException(string message, Exception innerException) : base(message, innerException)
    {
            
    }
}