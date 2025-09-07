using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiProject.Model.Entitties;

public class Certificate
{
    [Key]
    public Guid CertificateId { get; set; }

    [ForeignKey("ResultId")]
    public Guid ResultId { get; set; } // FK → Result
    public DateTime IssuedDate { get; set; }
      public Result? Result { get; set; } 
 }

