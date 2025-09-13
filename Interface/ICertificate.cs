using MyApiProject.Model.Entitties;

namespace MyApiProject.Interface;

public interface ICertificate
{
    Task<Certificate> CreateCertificateAsyn(Guid ResultId);
     Task<byte[]> GenerateCertificatePdfAsync(Guid resultId);
}