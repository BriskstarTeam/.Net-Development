using System.Collections.Generic;
using System.Threading.Tasks;
using Onion.Infrastructure;

namespace Onion.Service.Users
{
    public interface IUsersService
    {
        Task AddAsync(UserDTO userDM);
        Task UpdateAsync(UserDTO userDM);
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(long id);
        Task DeleteAsync(long id);
    }
}
