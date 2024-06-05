using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Polling_Page_Administration_Task.Data;
using Polling_Page_Administration_Task.Models;
using Polling_Page_Administration_Task.ViewModels;

namespace Polling_Page_Administration_Task.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> usermanager,
            SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            this.usermanager = usermanager;
            this.signInManager = signInManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var existuser = await usermanager.FindByNameAsync(userViewModel.UserName);
                if (existuser != null)
                {
                     return RedirectToAction("User Already exist with same UserName");
                }

                var existEmailuser = await usermanager.FindByEmailAsync(userViewModel.UserName);
                if (existEmailuser != null)
                {
                    return RedirectToAction("User Already exist with same Email");
                }
                //save
                var user = _mapper.Map<ApplicationUser>(userViewModel);
                IdentityResult result = await usermanager.CreateAsync(user, userViewModel.Password);
                if (result.Succeeded)
                {
                    await usermanager.AddToRoleAsync(user, UserRole.User.ToString());
                    return RedirectToAction("Index","Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
           return View(userViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await usermanager.FindByNameAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "please register in form registration");
            }
                if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetLastPoll", "Client");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }
    }
}
