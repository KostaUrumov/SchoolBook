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

        [HttpGet]
        public IActionResult RegisterDirector()
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
        public async Task<IActionResult> RegisterDirector(RegisterUserModel model)
        {
            model.Role = "Principal";
            var user = await uServ.AddUser(model);
            await uServ.AddToRole(user, model.Role);
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
