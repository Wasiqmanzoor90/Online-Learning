
namespace MyApiProject.DTO
{
    public class ExamDto
    {
      
        public required string Title { get; set; }
        public string? Description { get; set; }
        
        public DateTime Date { get; set; }
        public int Duration { get; set; }
            public Guid CreatedBy { get; set; }
        public IEnumerable<string>? Questions { get; set; }
    }
}