﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Personal_Patient.Models;
using Personal_Patient.Controllers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;


namespace Personal_Patient.Controllers
{
    public class HomeController : Controller
    {
        PersonalPatientContext db;
        public HomeController(PersonalPatientContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(CurrentPatient());
        }

        /// <summary>
        /// Получение текущего пользователя
        /// </summary>
        /// <returns></returns>
        protected Patient CurrentPatient()
        {
            var val = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            if (val == null)
                return null;
            Patient patient = db.patients.FirstOrDefault(p => p.email == val);
            return patient;
        }
    }
}
