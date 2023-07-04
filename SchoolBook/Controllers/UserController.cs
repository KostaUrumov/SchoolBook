using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;
using SchoolBook_Structure.Data;

namespace SchoolBook.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService uServ;
        private readonly SchoolBookDb data;
        public UserController(UserService _uServ, SchoolBookDb _data)
        {
            uServ = _uServ;
            data = _data;
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

        

    }
}
