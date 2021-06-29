using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Personal_Patient.Models;

namespace Personal_Patient.Controllers
{
    public class Account : Controller
    {
        PersonalPatientContext db;
        public Account(PersonalPatientContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Home(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            return View(db.patients.FirstOrDefault(p => p.id == id));
        }
    }
}
