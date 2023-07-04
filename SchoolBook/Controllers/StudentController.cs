using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.StudentModels;
using SchoolBook_Core.Services;
using System.Security.Claims;

namespace SchoolBook.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService sServ;

        public StudentController(StudentService _sServ)
        {
            sServ = _sServ;
        }

        [HttpGet]
        [Authorize(Policy = "ParentsOnly")]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "ParentsOnly")]
        public async Task<IActionResult> AddStudent(AddStudentModel student)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await sServ.AddStudent(student, userId);
            return RedirectToAction("Index", "Home");
        }

    }
}

    

