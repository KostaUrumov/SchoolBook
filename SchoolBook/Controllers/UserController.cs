using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;
using System.Security.Claims;

namespace SchoolBook.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService uServ;
        public UserController(UserService _uServ)
        {
            uServ = _uServ;
        }

        [HttpGet]
        public IActionResult RegisterPrincipal()
        {
            return View();
        }
        public IActionResult RegisterTeacher()
        {
            RegisterUserModel user = new RegisterUserModel()
            {
                Role = "Teacher"
            };
            return View(user);
        }
        public IActionResult RegisterParent()
        {
            RegisterUserModel user = new RegisterUserModel()
            {
                Role = "Parent"
            };
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPrincipal(RegisterUserModel model)
        {
           
            model.Role = "Principal";
            await uServ.AddUser(model);
            
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult RegisterTeacher(RegisterUserModel model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterParent(RegisterUserModel model)
        {
            return View(model);
        }

        

    }
}
