using Application.Dtos.Common;

namespace Application.Dtos.UserDtos;

public class UpdateUserDto : BaseDto
{
    public string UserName { get; set; }
    
}