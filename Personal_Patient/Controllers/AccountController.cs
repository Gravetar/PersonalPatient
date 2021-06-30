using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personal_Patient.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Personal_Patient.Controllers
{
    public class AccountController : Controller
    {
        private PersonalPatientContext _context;
        public AccountController(PersonalPatientContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.patients.FirstOrDefaultAsync(p => p.email == model.Email);
                if (patient == null)
                {
                    // добавляем пользователя в бд
                    patient = new Patient { 
                        email = model.Email, 
                        password = model.Password,
                        name = model.Name,
                        surname = model.Surname,
                        patronymic = model.Patronymic,
                        dateofbirth = DateTime.ParseExact(model.Dateofbirth, "yyyy-M-dd", CultureInfo.InvariantCulture),
                        numberpolicy = model.Numberpolicy,
                        numberpassport = model.Numberpassport,
                        phone = model.Phone
                    };

                    _context.patients.Add(patient);
                    await _context.SaveChangesAsync();

                    await Authenticate(patient); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Пользователь с такой почтой уже зарегистрирован");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.patients.FirstOrDefaultAsync(p => p.email == model.Email && p.password == model.Password);
                if (patient != null)
                {
                    await Authenticate(patient); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(Patient patient)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, patient.email)
            };

            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
