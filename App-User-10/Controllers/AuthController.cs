using APP_DATA_A_10.Models.Auth_User;
using App_User_10.Utilities;
using App_User_10.ViewModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App_User_10.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ==========================================================
        // GET: Auth/register
        // ==========================================================
        public IActionResult Register()
        {
            return View();
        }

        // ==========================================================
        // POST: Auth/register
        // ==========================================================
        [HttpPost]
        public IActionResult Register(RegisterViewM viewM)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(viewM.Username).Result;
                if (user == null)
                {
                    user = new AppUser()
                    {
                        UserName = viewM.Username,
                        FName = viewM.Firstname,
                        LName = viewM.Lastname,
                        Email = viewM.Email,

                    };
                    var result = _userManager.CreateAsync(user, viewM.Password).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(LogIn));
                    }
                    else
                    {
                        foreach (var erorr in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, erorr.Description);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username already exists.");
                }
            }

            return View(viewM);


        }

        // ==========================================================
        // GET: Auth/LogIn
        // ==========================================================
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }


        // ==========================================================
        // POST: Auth/LogIn
        // ==========================================================
        [HttpPost]
        public IActionResult LogIn(LoginViewM viewM)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(viewM.Email).Result;
                if (user != null)
                {
                    var passwordCheck = _userManager.CheckPasswordAsync(user, viewM.Password).Result;
                    if (passwordCheck != null)
                    {

                        var result = _signInManager.PasswordSignInAsync(user, viewM.Password, viewM.RememberMe, false).Result;

                        if (result.IsNotAllowed)
                        {
                            ModelState.AddModelError(string.Empty, "Your account is not allowed to log in.");
                        }
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError(string.Empty, "Your account is locked out.");
                        }
                        if (result.RequiresTwoFactor)
                        {
                            ModelState.AddModelError(string.Empty, "Your account requires two-factor authentication.");
                        }
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                            ModelState.AddModelError(string.Empty, "Login successful.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");

                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(viewM);
        }

        // ==========================================================
        // GET: Auth/LogOut
        // ==========================================================
        //[HttpGet]
        //[Authorize]
        //public IActionResult LogOut()
        //{
        //    _signInManager.SignOutAsync().GetAwaiter().GetResult();
        //    return RedirectToAction(nameof(LogIn));
        //}

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LogIn));
        }



        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgetPassword(ForgetPasswordViewM viewM)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(viewM.Email).Result;
                if (user != null)
                {
                    var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var resetPasswordLink = Url.Action(nameof(ResetPassword), "Auth", new { Email = viewM.Email, token }, Request.Scheme);
                    var email = new Email()
                    {
                        To = viewM.Email,
                        Subject = "Reset Password",
                        Body = resetPasswordLink

                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }
            return View(nameof(ForgetPassword), viewM);

        }


        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            TempData["Token"] = token;
            TempData["Email"] = email;
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewM viewM)
        {
            if (ModelState.IsValid)
            {
                string token = TempData["Token"] as string;
                string email = TempData["Email"] as string;
                var user = _userManager.FindByEmailAsync(email).Result;
                if (user != null)
                {
                    var result = _userManager.ResetPasswordAsync(user, token, viewM.NewPassword).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(LogIn));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }

                }



            }
            return View(viewM);

        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
