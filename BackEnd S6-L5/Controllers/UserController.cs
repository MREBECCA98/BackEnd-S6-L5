using BackEnd_S6_L5.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BackEnd_S6_L5.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd_S6_L5.Controllers
{

    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            string username = User.Identity.Name;
            return Content($"Ciao {username} questa pagina è solo per Admin");
        }


        [Authorize(Roles = "User")]
        public IActionResult Index2()
        {
            string username = User.Identity.Name;
            return Content($"Ciao {username} questa pagina è solo per User");
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(loginRequest.Email);

                    if (user != null)
                    {
                        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
                            user,
                            loginRequest.Password,
                            isPersistent: false,
                            lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
            }
            return View("Login");
        }



        //pagina di registrazione
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }




        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Save(RegisterRequest registerRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = registerRequest.Email,
                        Email = registerRequest.Email,
                        Name = registerRequest.Name,
                        Surname = registerRequest.Surname,
                        PhoneNumber = registerRequest.PhoneNumber,
                        CreatedAt = DateTime.Now,
                        Birthday = registerRequest.Birthday,
                        Id = Guid.NewGuid().ToString(),
                        IsDeleted = false,
                        EmailConfirmed = true,
                        LockoutEnabled = false,
                        Gender = " "
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);
                    if (result.Succeeded)
                    {

                        if (registerRequest.Email.ToLower() == "rebecca.matarozzo@gmail.com") //password= Epicode2025
                        {

                            if (!await _roleManager.RoleExistsAsync("Admin"))
                            {
                                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                            }
                            await _userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {

                            if (!await _roleManager.RoleExistsAsync("User"))
                            {
                                await _roleManager.CreateAsync(new IdentityRole("User"));
                            }
                            await _userManager.AddToRoleAsync(user, "User");
                        }

                        return RedirectToAction("Login");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View("Register");
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}