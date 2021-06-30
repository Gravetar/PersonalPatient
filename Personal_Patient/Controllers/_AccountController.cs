using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Personal_Patient.Models;

namespace Personal_Patient.Controllers
{
    public class _AccountController : Controller
    {
        PersonalPatientContext db;

        public _AccountController(PersonalPatientContext context)
        {
            db = context;
        }

        public IActionResult Index(string name, string password)
        {
            return View(db.patients.FirstOrDefault(p => p.name == name && p.password == password));
        }

        [HttpGet]
        public IActionResult Home(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            return View(db.patients.FirstOrDefault(p => p.id == id));
        }
    }
}
