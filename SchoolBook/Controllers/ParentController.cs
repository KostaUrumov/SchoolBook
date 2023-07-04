using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Core.Services;

namespace SchoolBook.Controllers
{
    public class ParentController : Controller
    {
        private readonly ParentService parServ;

        public ParentController(ParentService _parServ)
        {
            parServ = _parServ;
        }

        public IActionResult AllParents()
        {
            return View(parServ.GetAllParents());
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
            await parServ.AddParent(model);
            return RedirectToAction("AllParent", "Parent");
        }
    }
}
