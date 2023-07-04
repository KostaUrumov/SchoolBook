using Microsoft.AspNetCore.Mvc;
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
    }
}
