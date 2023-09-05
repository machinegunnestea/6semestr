using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using СonferenceWeb.Context;
using СonferenceWeb.Entities;
using СonferenceWeb.ViewModels;

namespace СonferenceWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ConferenceDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ConferenceDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user1 = new User
            {
                Email = model.Email,
                UserName = model.Email,
                Surname = model.Surname,
                Name = model.FirstName,
                PhoneNumber = model.Phone,
            };
            //if (await _userManager.FindByEmailAsync("someone@someone.com") == null)
            //{
            //    User user = new User()
            //    {
            //        UserName = "someone@someone.com",
            //        Email = "someone@someone.com"
            //    };

            //    await _userManager.CreateAsync(user, "Passw0rd123!");
            //    await _roleManager.CreateAsync(new IdentityRole("User"));

            //    IdentityResult result1 = await _userManager.AddToRoleAsync(user, "User");
            //}



            var result = await _userManager.CreateAsync(user1, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user1, "User");
                await _signInManager.SignInAsync(user1, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult ConferenceRegister()
        {
            ViewBag.Conferences = _context.Set<Conference>().ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Неверные данные");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);


            //if (!ModelState.IsValid)
            //    return View(model);

            //var user = await _userManager.FindByEmailAsync(model.Email);
            //if (user !=null)
            //{
            //    var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            //    if (passwordCheck)
            //    {
            //        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            //        if (result.Succeeded)
            //            return RedirectToAction("Index", "Home");
            //    }
            //    TempData["Error"] = "Неверные данные";
            //    return View(model);
            //}
            //TempData["Error"] = "Неверные данные";
            //return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConferenceRegister(ConferenceRegistration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Wrong username and/or password");
            }
            else
            {
                Members member = new Members();
                member.Name = _userManager.GetUserId(User);
                member.ConferenceId = model.ConferenceId;
                _context.Set<Members>().Add(member);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
        public IActionResult Login() => View(new LoginViewModel());
        public IActionResult Index()
        {
            return View();
        }
    }
}
