using MyApiProject.Data;
using MyApiProject.Extension;
using MyApiProject.Interface;
using MyApiProject.Model.Entitties;

namespace MyApiProject.Service.CertificateService;

public class CertificateService(SqlDbContext dbContext, PdfExtension pdfExtension) : ICertificate
{
    private readonly SqlDbContext _dbcontext = dbContext;
    private readonly PdfExtension _pdfextension = pdfExtension;

    public async Task<Certificate> CreateCertificateAsyn(Guid ResultId)
    {
        try
        {
            var certificate = new Certificate
            {
             CertificateId = Guid.NewGuid(),

                ResultId = ResultId,
                IssuedDate = DateTime.UtcNow
            };
            await _dbcontext.Certificates.AddAsync(certificate);
            await _dbcontext.SaveChangesAsync();
            return certificate;
        }
        catch (Exception ex)
        {

            throw new Exception("server error" + ex.Message);
        }
    }

    
    public async Task<byte[]> GenerateCertificatePdfAsync(Guid resultId)
        {
            var result = await _dbcontext.Results.FindAsync(resultId);
            if (result == null)
                throw new Exception("Result not found.");

            var exam = await _dbcontext.Exams.FindAsync(result.ExamId);
            var user = await _dbcontext.Users.FindAsync(result.UserId);

            if (exam == null || user == null)
                throw new Exception("Related data missing.");

            // Generate PDF certificate using PdfExtension
            var pdfBytes = await _pdfextension.GenerateCertificateAsync(
                "Certificate of Completion",
                exam.Title,
                user.Username,
                result.Score);

            return pdfBytes;
        }
}
