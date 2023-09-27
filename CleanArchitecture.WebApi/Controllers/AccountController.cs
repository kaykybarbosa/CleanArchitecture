using CleanArchitecture.Domain.Account;
using CleanArchitecture.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchitecture.WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            var result = await _authenticate.AuthenticateUserAsync(loginVM.Email, loginVM.Password);
            if (result)
            {
                if (loginVM.ReturnUrl.IsNullOrEmpty())
                    return RedirectToAction("Index", "Home");

                return Redirect(loginVM.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt (password must be strong).");
            return View(loginVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            var result = await _authenticate.RegisterUserAsync(registerVM.Email, registerVM.Password);
            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Register attemp (password must be strong).");
                return View(registerVM);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }
    }
}
