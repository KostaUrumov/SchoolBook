using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;
using System.Security.Claims;

namespace SchoolBook.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService uServ;
        private readonly SchoolBookDb data;
        private readonly SignInManager<User> signInManager;
        public UserController(
            UserService _uServ, 
            SchoolBookDb _data, 
            SignInManager<User> _signInManager)
        {
            uServ = _uServ;
            data = _data;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterUserModel model)
        {
            if (model.Username != "kostadin")
            {
                return RedirectToAction("Index", "Home");
            }
            bool adminRegistered = data.UserRoles.Any(r => r.RoleId == "0ft3109e-3t4e-446f-46he-085116fr7450");
            if (adminRegistered == true)
            {
                return RedirectToAction("Index", "Home");
            }
            await uServ.AddAdmin(model);
            return RedirectToAction("Index", "Home");
        }



        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel model)
        {
            await uServ.LogIn(model);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Logout ()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
