using Microsoft.AspNetCore.Mvc;
using MyApiProject.Interface;

namespace MyApiProject.Controller;


[ApiController]
[Route("api/[controller]")]
public class CertificateController(ICertificate certificate) : ControllerBase
{
    private readonly ICertificate _certificate = certificate;



[HttpPost]
    public async Task<IActionResult> CreateCertificate(Guid ResultId)
    {
        try
        {
            var certificate = await _certificate.CreateCertificateAsyn(ResultId);
            return Ok(certificate);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred: " + ex.Message);
        }

    }

[HttpGet]
    public async Task<IActionResult> GenrateCertificate(Guid ResultId)
    {
        try
        {
            var res = await _certificate.GenerateCertificatePdfAsync(ResultId);
            return File(res, "application/pdf", "Certificate.pdf");
        }
        catch (Exception ex)
        {

            return StatusCode(500, "An error occurred: " + ex.Message);
        }
    }
}