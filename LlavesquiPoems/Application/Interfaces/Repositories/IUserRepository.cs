using LlavesquiPoems.Application.Dtos;

namespace LlavesquiPoems.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<List<OrderDto>> GetOrdersByUserId(int userId);
    Task<List<RewardDto>> GetRewardsByUserId(int userId);
    
}