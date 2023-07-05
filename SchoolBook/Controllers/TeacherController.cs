using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;
using SchoolBook_Structure.Entities;
using System.Security.Claims;

namespace SchoolBook.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TeacherService tServ;

        public TeacherController(TeacherService _tServ)
        {
            tServ = _tServ;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllTeachers()
        {
            return View(tServ.GetAllTeachers());
        }

        [HttpGet]
        [Authorize(Policy = "AdminsOnly")]
        public IActionResult RegisterTeacher()
        {

            return View();
        }


        [HttpPost]
        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> RegisterTeacher(TeacherRegisterModel model)
        {
            await tServ.AddTeacher(model);

            return RedirectToAction(nameof(AllTeachers));
        }

        [Authorize(Policy = "AdminsOnly")]
        public async Task<IActionResult> BecomePrincipal (string teacherId)
        {
            await tServ.RemovePrincipal();
            await tServ.BecomePrincipal(teacherId);
            return RedirectToAction(nameof(AllTeachers));
        }

        [HttpPost]
        [Authorize(Policy = "TeachersOnly")]
        public async Task<IActionResult> AddToMyClass(int studentId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await tServ.AddToMyClass(userId, studentId);
            return RedirectToAction(nameof(MyClass));
        }

        
        [Authorize(Policy = "TeachersOnly")]
        public IActionResult MyClass()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return View(tServ.MyClass(userId));
        }

        
        [Authorize(Policy = "TeachersOnly")]
        public async Task<IActionResult> RemoveFromMyClass(int studentId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await tServ.RemoveFromClass(userId, studentId);
            return RedirectToAction(nameof(MyClass));
        }
    }
}
