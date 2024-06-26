﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaM.Core.Models.ApplicationUser;
using PharmaM.Data;
using PharmaM.Infrastructure.Data.Common;
using PharmaM.Infrastructure.Data.Models;

namespace PharmaM.Controllers
{
    public class ApplicationUserController : Controller
    {
        // injecting the AppDbContext to the controller
        private readonly PharmaMDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public ApplicationUserController(PharmaMDbContext context
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Users.ToListAsync();
            return View();
        }

        public IActionResult LogIn()
        {
            var data = new LogInViewModel();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel LogInData)
        {
            if (!ModelState.IsValid)
            {
                return View(LogInData);
            }

            var user = await _userManager.FindByEmailAsync(LogInData.EmailAddress);
            if (user != null)
            {
                var validationCheck = await _userManager.CheckPasswordAsync(user, LogInData.Password);
                if (validationCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, LogInData.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Please check you credentials again!";
                return View(LogInData);
            }

            TempData["Error"] = "Please check you credentials again!";
            return View(LogInData);
        }

        public IActionResult SignUp()
        {
            var data = new SignUpViewModel();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel RegisterData)
        {
            if (!ModelState.IsValid)
                return View(RegisterData);

            //Check for username
            var userName = await _userManager.FindByNameAsync(RegisterData.UserName);
            if (userName != null)
            {
                TempData["Error"] = "This username is taken!";
                return View(RegisterData);
            }

            //Check for e-mail
            var user = await _userManager.FindByEmailAsync(RegisterData.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email is already registered!";
                return View(RegisterData);
            }

            // Check for password format
            var passwordValidator = _userManager.PasswordValidators.First();
            var passwordValidationResult = await passwordValidator.ValidateAsync(_userManager, null, RegisterData.Password);

            if (!passwordValidationResult.Succeeded)
            {
                // Password format is not valid
                TempData["Error"] = "Invalid password format. " +
                                   "Please ensure your password meets the security requirements.";
                return View(RegisterData);
            }

            var newUser = new ApplicationUser()
            {
                FirstName = RegisterData.FirstName,
                LastName = RegisterData.LastName,
                Address = RegisterData.Address,
                Email = RegisterData.EmailAddress,
                UserName = RegisterData.UserName
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, RegisterData.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegistrationCompleted");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
