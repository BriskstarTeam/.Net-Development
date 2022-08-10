using Onion.Repository.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Onion.Repository.Users
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task Update(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(long id);
        Task Delete(long id);
    }
}
