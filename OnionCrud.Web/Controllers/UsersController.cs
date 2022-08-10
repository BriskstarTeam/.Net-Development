using System;
using System.Threading.Tasks;
using ElmahCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Infrastructure;
using Onion.Repository.Constants;
using Onion.Service.Users;

namespace Onion.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _userService;
        private IHttpContextAccessor _httpContextAccessor;
        public UsersController(IUsersService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Create a list User 
        /// </summary>
        /// <returns></returns>
        /// <created on>09 Aug 2022</created>
        /// <description>Create a new method for listing a user</description>
        /// <created by>Vikas</created>
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllAsync());
        }

        public async Task<IActionResult> Details(long id)
        {
            if (id == AppConstants.NumberZero)
            {
                return NotFound();
            }
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Create a new User 
        /// </summary>
        /// <returns></returns>
        /// <created on>09 Aug 2022</created>
        /// <description>Create a new method for creating a user</description>
        /// <created by>Vikas</created>
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(UserDTO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userService.AddAsync(user);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
            return View(user);
        }

        /// <summary>
        /// Create a edit User 
        /// </summary>
        /// <returns></returns>
        /// <created on>09 Aug 2022</created>
        /// <description>Create a new method for editing a user</description>
        /// <created by>Vikas</created>
        public async Task<IActionResult> Edit(long id)
        {
            if (id == AppConstants.NumberZero)
            {
                return NotFound();
            }

            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Edit(long id,
            UserDTO user)
        {
            try
            {
                if (id != user.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    await _userService.UpdateAsync(user);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception exception)
            {
                await _httpContextAccessor.HttpContext.RiseError(exception);
            }
            return View(user);
        }

        /// <summary>
        /// Create a delete User 
        /// </summary>
        /// <returns></returns>
        /// <created on>09 Aug 2022</created>
        /// <description>Create a new method for deleteing a user</description>
        /// <created by>Vikas</created>
        public async Task<IActionResult> Delete(long id)
        {
            if (id == AppConstants.NumberZero)
            {
                return NotFound();
            }
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
