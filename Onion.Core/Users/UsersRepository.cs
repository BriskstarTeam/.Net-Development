using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElmahCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Onion.Repository.Users.Models;

namespace Onion.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly OnionCrudDBContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public UsersRepository(OnionCrudDBContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        [Obsolete]
        public async Task Add(User user)
        {
            try
            {
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
        }

        [Obsolete]
        public async Task Delete(long id)
        {
            try
            {
                var result = await _context.User.Where(e => e.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    _context.User.Remove(result);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
        }

        public async Task<List<User>> GetAll()
        {
            var result = await _context.User.ToListAsync();
            return result;
        }

        public async Task<User> GetById(long id)
        {
            var result = await _context.User.Where(e => e.Id == id).FirstOrDefaultAsync();
            return result;
        }

        [Obsolete]
        public async Task Update(User user)
        {
            try
            {
                _context.User.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
        }
    }
}
