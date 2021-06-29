using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Personal_Patient.Models;

namespace Personal_Patient.Controllers
{
    public class HomeController : Controller
    {
        PersonalPatientContext db;
        public HomeController(PersonalPatientContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.patients.ToList());
        }

        [HttpPost]
        public IActionResult Account(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            
            return View(db.patients.FirstOrDefault(p => p.id == id));
        }
    }
}
