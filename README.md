# export-html-nuget

This library is a client to use the ExportHtml Service that converts a html file to pdf or a png screenshot.

## Installation

you can install it by adding the following code in your startup.cs:


    services.AddExportHtmlClient(configure =>
    {
        configure.BaseUrl = "";
        configure.TimeOut = 10000;
    });

or it is possible to add a configuration section:

    var section = configuration.GetSection("Your section");
    services.AddExportHtmlClient(section);

## Examples

Usage by constructor injection:

    private IHtmlExportRepository _exportRepository;
    
    public TestService(IHtmlExportRepository exportRepository)
    {
        _exportRepository = exportRepository;
    }

### Html to Pdf

    public async Task ExampleToPdf()
    {
        var htmlCode = "<p>Test Html Text</p>";

        var stream = await _exportRepository.ToPdfFromHtml(
            htmlCode);
    }

With base64 converting and other format:

    public async Task ExampleWithMoreParameter()
    {
        var htmlCode = "<p>Test Html Text</p>";

        var stream = await _exportRepository.ToPdfFromHtml(
            htmlCode,
            convertToBase64: true,
            formats: PdfFormats.A4);
    }

### Html to Screenshot

    public async Task ExampleToScreenshot()
    {
        var htmlCode = "<p>Test Html Text</p>";

        var stream = await _exportRepository.ToScreenshotFromHtml(
            htmlCode);
    }

Have fun with the library! :-)

