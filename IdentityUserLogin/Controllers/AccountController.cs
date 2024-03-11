using IdentityUserLogin.Core.DTO;
using IdentityUserLogin.Core.Services.UserService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IdentityUserLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAdderService _userAdderService;
        public AccountController(IUserAdderService userAdderService)
        {
            _userAdderService = userAdderService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel userRegistration)
        {
            if(ModelState.IsValid)
            {
                var result = await _userAdderService.CreateUser(userRegistration);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index),"Home");
                }
            }
            return View(userRegistration);
        }
    }
}
