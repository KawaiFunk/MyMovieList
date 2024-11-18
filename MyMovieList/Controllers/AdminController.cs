using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMovieList.Logic.Data.Entities;
using MyMovieList.Web.Models;

namespace MyMovieList.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                // Map UserModel to User entity
                var user = new User
                {
                    UserName = userModel.Name,
                    Email = userModel.Email
                };

                // Create user with the plain text password
                IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(userModel); // Return the same model to the view if validation fails
        }
    }
}
