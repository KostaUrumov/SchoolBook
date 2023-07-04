using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;

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

    }
}
