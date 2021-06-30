using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Personal_Patient.Models;
using Personal_Patient.Controllers;

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
            return View();
        }
    }
}
