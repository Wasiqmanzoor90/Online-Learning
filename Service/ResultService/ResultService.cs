using Microsoft.EntityFrameworkCore;
using MyApiProject.Data;
using MyApiProject.DTO;
using MyApiProject.Interface;
using MyApiProject.Model.Entitties;

namespace MyApiProject.Service;


public class ResultService(SqlDbContext dbContext) : ResultInterface
{
    private readonly SqlDbContext _dbcontext = dbContext;



    public async Task<bool> PostResultAsync(ResultDto resultDto)
    {
        try
        {
            var user = await _dbcontext.Users.FindAsync(resultDto.UserId);
            var exam = await _dbcontext.Exams.FindAsync(resultDto.ExamId);
            if (user == null || exam == null)
            {
                throw new Exception("UserId missing or Examid missing");
            }

            var res = new Result
            {
                ResultId = new Guid(),
                UserId = resultDto.UserId,
                ExamId = resultDto.ExamId,
                Score = resultDto.Score,
                AttemptDate = resultDto.AttemptDate,
                Status = resultDto.Status

            };
            await _dbcontext.AddAsync(res);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {

            throw new Exception("Server error" + ex.Message);
        }
    }
    
     public async Task<ResultDto> GetResultAsync(Guid userId, Guid examId)
{
    try
    {
        // Check if user exists
        var user = await _dbcontext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        if (user == null)
        {
            throw new ArgumentException("User not found");
        }

        // Get the result for the specific user and exam
        var result = await _dbcontext.Results
            .FirstOrDefaultAsync(r => r.ExamId == examId && r.UserId == userId);
        
        if (result == null)
        {
            throw new ArgumentException("Result not found for the specified user and exam");
        }

        // Map to DTO and return
        var resultDto = new ResultDto
        {
            // Map properties from result entity to DTO
            ExamId = result.ExamId,
            UserId = result.UserId,
            Score = result.Score,
            // Add other properties as needed
        };

        return resultDto;
    }
    catch (ArgumentException)
    {
        // Re-throw validation exceptions as-is
        throw;
    }
    catch (Exception ex)
    {
        // Log the exception here if you have logging
        throw new Exception($"Server error: {ex.Message}", ex);
    }
}
}