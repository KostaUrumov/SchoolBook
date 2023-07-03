using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;

namespace SchoolBook.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService uServ;
        public UserController(UserService _uServ)
        {
            uServ = _uServ;
        }

        public IActionResult RegisterDirector()
        {
            RegisterUserModel user = new RegisterUserModel()
            {
                Role = "Principal"
            };

            return View(user);
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

        [HttpGet]
        public IActionResult RegisterDirector(RegisterUserModel model)
        {
            return View(model);
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

        [HttpPost]
        public async Task<IActionResult> Reg(RegisterUserModel model)
        {
            await uServ.AddUser(model);
            return View();
        }

    }
}
