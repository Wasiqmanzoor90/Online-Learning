using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Fonts;

namespace MyApiProject.Extension;

public class PdfExtension
{
    static PdfExtension()
    {
        // Add this line to fix font issues
        GlobalFontSettings.FontResolver = new FontResolver();
    }

    public async Task<byte[]> GenerateCertificateAsync(string certificateTitle, string examTitle, string username, float score)
    {
        using (var stream = new MemoryStream())
        {
            // Create new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Certificate";

            // Create an empty page
            PdfPage page = document.AddPage();

            // Create graphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Now you can use Google Fonts (put Roboto-Regular.ttf and Roboto-Bold.ttf in Fonts folder)
            XFont titleFont = new XFont("Roboto", 20, XFontStyle.Bold);
            XFont normalFont = new XFont("Roboto", 12, XFontStyle.Regular);

            // Draw title
            gfx.DrawString(certificateTitle, titleFont, XBrushes.Black,
                new XRect(0, 50, page.Width, 40),
                XStringFormats.TopCenter);

            // Draw user name
            gfx.DrawString($"Awarded to: {username}", normalFont, XBrushes.Black,
                new XRect(0, 120, page.Width, 20),
                XStringFormats.TopCenter);

            // Draw exam name
            gfx.DrawString($"For completing the exam: {examTitle}", normalFont, XBrushes.Black,
                new XRect(0, 150, page.Width, 20),
                XStringFormats.TopCenter);

            // Draw score
            gfx.DrawString($"Score: {score}", normalFont, XBrushes.Black,
                new XRect(0, 180, page.Width, 20),
                XStringFormats.TopCenter);

            // Save the document into the MemoryStream
            document.Save(stream, false);

            // Return as byte array
            return await Task.FromResult(stream.ToArray());
        }
    }
}

// Minimal font resolver
public class FontResolver : IFontResolver
{
    public string DefaultFontName => "Roboto-Regular";

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        return new FontResolverInfo(isBold ? "Roboto-Bold" : "Roboto-Regular");
    }

    public byte[] GetFont(string faceName)
    {
        var fontPath = Path.Combine("Fonts", faceName == "Roboto-Bold" ? "Roboto-Bold.ttf" : "Roboto-Regular.ttf");
        return File.ReadAllBytes(fontPath);
    }
}