using Microsoft.AspNetCore.Authorization;
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
            bool adminRegistered = data.UserRoles.Any(r => r.RoleId == "0ft3109e-3t4e-446f-46he-085116fr7450");
            if (adminRegistered == true)
            {
                return RedirectToAction("Index", "Home");
            }
            await uServ.AddAdmin(model);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize(Policy = "AdminsOnly")]
        public IActionResult RegisterTeacher()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminsOnly")]
        public async Task <IActionResult> RegisterTeacher(TeacherRegisterModel model)
        {
            await uServ.AddTeacher(model);

            return View(model);
        }


        [HttpGet]
        [Authorize(Policy = "AdminsOnly")]
        public IActionResult RegisterParent()
        {
            return View();
        }
        

        [HttpPost]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> RegisterParent(RegisterParentModel model)
        {
            await uServ.AddParent(model);
            return View(model);
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
