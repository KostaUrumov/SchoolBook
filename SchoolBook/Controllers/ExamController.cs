using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.ExamModels;
using SchoolBook_Core.Services;
using SchoolBook_Structure.Entities;
using System.Security.Claims;

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
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await eServ.AddExam(model);
            await eServ.AddStudentsToTheExam(userId, model);
            return RedirectToAction(nameof(AllExams));
        }

        [Authorize]
        public IActionResult AllExams()
        {
            return View(eServ.AllExams());
        }

        [Authorize(Policy = "TeachersOnly")]
        public IActionResult Participants(int examId)
        {
            return View(eServ.CheckParticipants(examId));
        }

        
        public IActionResult Evaluate(int examId, int stundentId)
        {
            var findStudentExam = eServ.FindSE(examId, stundentId);  
            
            return View(findStudentExam);
        }

        
        public IActionResult Evaluate(StudentExam example, int examId, int stundentId)
        {
            
            return View();
        }


    }
}
