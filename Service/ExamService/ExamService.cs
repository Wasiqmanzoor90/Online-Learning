using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;
using MyApiProject.DTO;
using MyApiProject.Interface;
using MyApiProject.Model.Entitties;
using MyApiProject.Model.Enum;


namespace MyApiProject.Service.ExamService;

public class ExamService(SqlDbContext dbContext) : IExam
{
    private readonly SqlDbContext _dbcontext = dbContext;

    public async Task<bool> CreateExamAsync(ExamDto examDto)
    {
        try
        {
            var user = await _dbcontext.Users.FindAsync(examDto.CreatedBy);
            if (user == null)
            {
                throw new Exception("Invalid CreatedBy user.");
            }
            var exam = new Exam
            {
                ExamId = new Guid(),
                Title = examDto.Title,
                Description = examDto.Description,
                DurationMinutes = examDto.Duration,
                CreatedBy = examDto.CreatedBy,
                Questions = new List<Question>()


            };
            if (examDto.Questions != null && examDto.Questions.Any())
            {
                foreach (var Questionstext in examDto.Questions)
                {
                    var question = new Question
                    {
                        QuestionId = Guid.NewGuid(),
                        ExamId = exam.ExamId,
                        Text = Questionstext,
                        QuestionType = QuestionType.MultipleChoice,
                        Options = "[\"Option 1\", \"Option 2\", \"Option 3\", \"Option 4\"]",
                        CorrectAnswer = "Option 1"
                    };

                    exam.Questions.Add(question);
                }
            }

            await _dbcontext.AddAsync(exam);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.InnerException?.Message);
            throw;
        }
    }


   public async Task<List<Exam>> GetAllExamsAsync(Guid userId)
    {
        try
        {
            return await _dbcontext.Exams
                .Where(e => e.CreatedBy == userId)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving exams.", ex);
        }
    }


 
   

    public async Task<Exam> GetExamByIdAsync(Guid id)
    {
        try
        {
            var exam = await _dbcontext.Exams.FindAsync(id);
            if (exam == null)
            {
                throw new Exception("Exam not found.");
            }
            return exam;
        }
        catch (Exception)
        {

            throw new Exception("Error retrieving exam.");
        }

    }
}
