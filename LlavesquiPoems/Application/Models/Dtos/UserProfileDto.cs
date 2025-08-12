using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Dtos;

public class UserProfileDto
{
    public UserDto BasicData { get; set; }
    public List<OrderDto> Orders { get; set; }
    public List<RewardDto> Rewards { get; set; }
    
}