using CoreWithADO.DataAccess;
using CoreWithADO.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreWithADO.Controllers
{
    public class AccountController : Controller
    {
        DBUserAuth dBUser = new DBUserAuth();

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> Login(UserSignIn user)
        {
            if (ModelState.IsValid)
            {
                var result = dBUser.LoginUser(user);
                if (result)
                {
                    var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.email)),
                        new Claim(ClaimTypes.Name, user.password),

                };
                    //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                    var principal = new ClaimsPrincipal(identity);
                    //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password !");
                }
            }
            return View(user);
        }

        public IActionResult Register()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult Register(UserSignUp user)
        {
            if (ModelState.IsValid)
            {
                var result = dBUser.RegisterUser(user);
                if(result)
                {
                    ViewBag.success = "User registered successfully !";
                }
                else
                {
                    ModelState.AddModelError("Email", "Email already exist !");
                }
            }

            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }

   
}
