using ElmahCore;
using Microsoft.AspNetCore.Http;
using Onion.Infrastructure;
using Onion.Repository.Users;
using Onion.Repository.Users.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Service.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public UsersService(IUsersRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [Obsolete]
        public async Task AddAsync(UserDTO userDM)
        {
            try
            {
                await _userRepository.Add(new User
                {
                    FirstName = userDM.FirstName,
                    MiddleName = userDM.MiddleName,
                    LastName = userDM.LastName
                });
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
        }

        [Obsolete]
        public async Task DeleteAsync(long id)
        {
            try
            {
                await _userRepository.Delete(id);
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            var userList = new List<UserDTO>();
            var result = await _userRepository.GetAll();
            foreach (var item in result)
            {
                userList.Add(new UserDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    MiddleName = item.MiddleName,
                    LastName = item.LastName
                });
            }
            return userList;
        }

        public async Task<UserDTO> GetByIdAsync(long id)
        {
            var result = await _userRepository.GetById(id);
            var userDM = new UserDTO
            {
                Id = result.Id,
                FirstName = result.FirstName,
                MiddleName = result.MiddleName,
                LastName = result.LastName
            };
            return userDM;
        }

        [Obsolete]
        public async Task UpdateAsync(UserDTO userDM)
        {
            try
            {
                await _userRepository.Update(new User
                {
                    Id = userDM.Id,
                    FirstName = userDM.FirstName,
                    MiddleName = userDM.MiddleName,
                    LastName = userDM.LastName
                });
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
        }
    }
}
