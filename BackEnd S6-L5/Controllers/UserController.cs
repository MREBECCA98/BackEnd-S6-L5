using BackEnd_S6_L5.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BackEnd_S6_L5.Models.Dto;

namespace BackEnd_S6_L5.Controllers
{
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

        public IActionResult Index()
        {
            return View();
        }

        //pagina di registrazione
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Save(RegisterRequest registerRequest)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            ApplicationUser user = new ApplicationUser()
        //            {
        //                UserName = registerRequest.Email,
        //                Email = registerRequest.Email,
        //                Name = registerRequest.Name,
        //                Surname = registerRequest.Surname,
        //                PhoneNumber = registerRequest.PhoneNumber,
        //                CreatedAt = DateTime.Now,
        //                Birthday = registerRequest.Birthday,
        //                Id = Guid.NewGuid().ToString(),
        //                IsDeleted = false,
        //                EmailConfirmed = true,
        //                LockoutEnabled = false



        //            };
        //            IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);
        //            if (result.Succeeded)
        //            {


        //                var roleExist = await this._roleManager.RoleExistsAsync("User");
        //                if (roleExist)
        //                {
        //                    await this._roleManager.CreateAsync(new IdentityRole("User"));


        //                }
        //                await this._userManager.AddToRoleAsync(user, "User");

        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
    }
}