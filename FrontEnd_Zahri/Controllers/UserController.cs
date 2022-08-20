using FrontEnd_Zahri.Models;
using FrontEnd_Zahri.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd_Zahri.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            try
            {
                var result = await _user.Insert(userRegister);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserRegister user)
        {
            try
            {
                var result = await _user.Login(user);

                if (string.IsNullOrEmpty(HttpContext.Session.GetString("token")))
                {
                    HttpContext.Session.SetString("token", $"Bearer {result.Token}");
                }

                //TempData["pesan"] = $"{result.Token}";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewData["pesan"] = $"<div class='alert alert-success alert-dismissible fade show'><button type='button' class='btn-close' data-bs-dismiss='alert'></button> Error: {ex.Message}</div>";
                return View();
            }
        }


    }
}
