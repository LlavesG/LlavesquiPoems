using LlavesquiPoems.Application.Models.Dtos;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IQuizzesService
{
    Task<QuizDto?> GetByIdAsync(int id);
    Task<List<QuizDto>?> GetListAsync();
    Task<QuizDto?> InsertAsync(QuizDto dto);
    Task UpdateAsync(QuizDto dto);

}