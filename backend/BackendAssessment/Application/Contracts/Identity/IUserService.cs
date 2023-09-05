using Application.DTO.Identity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<UserDataDTO?> GetProfile(string Id);

        Task<UserDataDTO?> UpdateProfile(string Id, UpdateUserProfileDTO userData);

        Task<bool> ChangePassword(string Id, ChangePasswordDTO changePasswordDTO);



    }
}
