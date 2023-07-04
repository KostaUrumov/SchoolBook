using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.ExamModels;
using SchoolBook_Core.Services;

namespace SchoolBook.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamService eServ;
        public ExamController(ExamService _eServ)
        {
            eServ = _eServ;
        }

        [HttpGet]
        [Authorize(Policy = "TeachersOnly")]
        public IActionResult AddExam()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "TeachersOnly")]
        public async Task<IActionResult> AddExam(AddExamModel model)
        {
            await eServ.AddExam(model);
            return RedirectToAction(nameof(AllExams));
        }

        public IActionResult AllExams()
        {
            return View(eServ.AllExams());
        }

    }
}
