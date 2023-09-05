using Application.Contracts.Identity;
using Application.DTO.Identity.DTO;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Entites;

namespace Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> ChangePassword(string Id, ChangePasswordDTO changePasswordData)
        {
            var user = await _userManager.FindByIdAsync(Id);

            await _userManager.ChangePasswordAsync(user, changePasswordData.PreviousPassword, changePasswordData.NewPassword);

            return true;
        }





        public async Task<UserDataDTO?> GetProfile(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            var userProfile = new UserDataDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
            return userProfile;

        }

        public async Task<UserDataDTO> UpdateProfile(string Id, UpdateUserProfileDTO userData)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);

                if (user == null)
                {
                    throw new Exception();
                }

                user.FirstName = userData.FirstName;
                user.LastName = userData.LastName;
                await _userManager.UpdateAsync(user);
                return await GetProfile(Id);
            }
            catch (Exception ex)
            {
                throw new BadRequestException("Not able to create User");
            }
        }

    }
}
