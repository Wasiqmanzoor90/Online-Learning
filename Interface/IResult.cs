using MyApiProject.DTO;

namespace MyApiProject.Interface;

public interface ResultInterface
{
    public Task<bool> PostResultAsync(ResultDto resultDto);
       Task<ResultDto> GetResultAsync(Guid userId, Guid examId);

 }