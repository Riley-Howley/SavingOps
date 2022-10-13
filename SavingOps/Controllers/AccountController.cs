using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace SavingOps.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            SignInManager<IdentityUser> SignInManager;

            await _signInManager.SignOutAsync();
            return RedirectToAction("Dashboard","Home");
        }
    }
}