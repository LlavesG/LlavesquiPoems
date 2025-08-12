using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Application.Models.Dtos;
using LlavesquiPoems.Application.Services.Sessions;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Services;

public class QuizzesService : IQuizzesService
{
    private readonly IGenericRepository<Quiz> _genericQuizRepository;
    private readonly IGenericRepository<AnswersUser> _genericAnswerRepository;
    private readonly ISessionService _sessionService;

    public QuizzesService(IGenericRepository<Quiz> genericRepository,IGenericRepository<AnswersUser> answeRepository, ISessionService sessionService)
    {
        _genericQuizRepository = genericRepository;
        _genericAnswerRepository = answeRepository;
        _sessionService = sessionService;
    }

    public async Task<QuizDto?> GetByIdAsync(int id)
    {
        var quiz = await _genericQuizRepository.GetByIdAsync(id);
        return quiz == null
            ? null
            : new QuizDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                Description = quiz.Description,
                Answers = quiz.AnswersUsers.Count(),
                CreatedAt = quiz.CreatedAt,
                DeadLine = quiz.DeadLine,
                IdProduct = quiz.IdProduct,
                IsAnswered =  _genericAnswerRepository.Exists(x => x.IdQuiz == quiz.Id && x.IdUser == _sessionService.CurrentSession().Id),
            };
    }

    public async Task<List<QuizDto>?> GetListAsync()
    {
        var quizzes = await _genericQuizRepository.GetAllAsync();
        quizzes.Where(x => x.DeadLine > DateTime.UtcNow);
        var enumerable = quizzes.ToList();
        return enumerable.Select(Mapper.QuizMapper.ToDto).ToList();
    }

    public async Task<QuizDto?> InsertAsync(QuizDto dto)
    {
        _genericQuizRepository.BegingTransaction();
        QuizDto newQuiz;
        try
        {
            var quiz = Mapper.QuizMapper.ToEntity(dto);
            quiz = await _genericQuizRepository.AddAsync(quiz);
            newQuiz = Mapper.QuizMapper.ToDto(quiz);
        }
        catch (Exception ex)
        {
            _genericQuizRepository.RollbackTransaction();
            throw new Exception("Error inserting user", ex);
        }

        _genericQuizRepository.SaveChanges();
        return newQuiz;
    }

    public async Task UpdateAsync(QuizDto dto)
    {
        var quiz = Mapper.QuizMapper.ToEntity(dto);
        await _genericQuizRepository.UpdateAsync(quiz);
    }
}