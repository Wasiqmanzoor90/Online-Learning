
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MyApiProject.Data;
using MyApiProject.DTO;
using MyApiProject.Interface;
using MyApiProject.Model.Entitties;
using MyApiProject.Model.Enum;

namespace MyApiProject.Service;

public class QuestionService(SqlDbContext dbContext) : IQuestion
{
    private readonly SqlDbContext _dbcontext = dbContext;

    public async Task<bool> CreateQuestionAsync(QuestionDto questionDto)
    {
        try
        {


            var user = await _dbcontext.Users.FindAsync(questionDto.CreatedBy);
            if (user == null)
            {
                throw new Exception("Invalid CreatedBy user.");
            }

            var question = new Question
            {
                QuestionId = Guid.NewGuid(),
                ExamId = questionDto.ExamId,
                CreatedBy = questionDto.CreatedBy,
                Text = questionDto.Text,
                QuestionType = questionDto.QuestionType,
                Options = questionDto.Options,
                
            };

            await _dbcontext.AddAsync(question);
            await _dbcontext.SaveChangesAsync();
            return true;

        }
        catch (Exception ex)
        {

            throw new Exception("Server error" + ex);
        }
    }


    public async Task<List<Question>> GetquestionsByExamId(Guid UserId)
    {
        try
        {
            return await _dbcontext.Questions
            .Where(e => e.ExamId == UserId).ToListAsync();
        }
        catch (Exception ex)
        {

            throw new Exception("Error retrieving exams.", ex);
        }

    }


    public async Task<bool> DeleteQuestionAsync(Guid QuestionId)
    {
        try
        {
          
            var qst = await _dbcontext.Questions.FindAsync(QuestionId);
            if (qst == null)
            {
                throw new Exception("QuestionId is missing");
            }

            _dbcontext.Questions.Remove(qst);
            await _dbcontext.SaveChangesAsync();
            return true;
     }
        catch (Exception ex)
        {

            throw new Exception("Server erro", ex);
        }
    }

}