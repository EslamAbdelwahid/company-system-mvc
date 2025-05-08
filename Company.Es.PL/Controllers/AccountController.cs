using Company.Es.DAL.Models;
using Company.Es.PL.Helper;
using Company.Es.PL.ViewModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.Es.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
        {
			this.userManager = userManager;
            this.signInManager = signInManager;
        }
		#region SignUp
		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = await userManager.FindByNameAsync(model.UserName);
					if (user is null)// mean this user didn't exists
					{
						user = await userManager.FindByEmailAsync(model.Email);
						if (user is null)
						{
							user = new ApplicationUser()
							{
								UserName = model.UserName,
								FirstName = model.FirstName,
								LastName = model.LastName,
								Email = model.Email,
								IsAgree = model.IsAgree
							};
							var result = await userManager.CreateAsync(user, model.Password);
							if (result.Succeeded)
							{
								return RedirectToAction("SignIn");
							}

							foreach (var error in result.Errors)
							{
								ModelState.AddModelError(string.Empty, error.Description);
							}
						}
						ModelState.AddModelError(string.Empty, "This Email Already Exists");
						return View(model);
					}
					ModelState.AddModelError(string.Empty, "This UserName Already Exists");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			return View(model);
		} 
		#endregion

		#region SignIn
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = await userManager.FindByEmailAsync(model.Email);
					if (user is not null)
					{
						bool flag = await userManager.CheckPasswordAsync(user, model.Password);
						if (flag)
						{
							// must generate a token to let you go to any page (Identity for you)
							var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
							// here (RememberMe variable) if true-> the identity will  store in cokies in browsesr for 14 days (this is defualt period)
							// false value refere to not block any user now
							if (result.Succeeded)
							{
								return RedirectToAction("Index", "Home");
							}
						}
					}
					ModelState.AddModelError(string.Empty, "Invalid LogIn!!");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}

			}
			return View(model);
		}
		#endregion

		#region SignOut
		public new async Task<IActionResult> SignOut()
		{
			// I use newe keyword here why??
			// --> as there exists a function in base class with the same name

			// Note: I can make this Action void -> it will redirect my automaticly to SignIn page
			await signInManager.SignOutAsync();
			return RedirectToAction(nameof(SignIn));
		}
		#endregion

		#region Forget Password

		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SendResetPasswordUrl(ForgetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await userManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
					// 1. Create token to avoid anyone to guess any email and change the password for this email
					// Identity Packadge will create this token
					// I must make this token is unique (hardest for anyone to guess) and valid for one time only,
					// also you can make the expiration for this token 10 seconds for exampl!

					var token = await userManager.GeneratePasswordResetTokenAsync(user);
					// 2. Create Reset Password URL
					var url = Url.Action("ResetPassword", "Account", new { email = user.Email, token = token }, Request.Scheme);
					// here (Request.Schema) contains (protocol+host+fragment)
					// url example: https://localhost:44318/Account/ResetPassword?email=eslam@gmai.com&token=xyz
					var email = new Email()
					{
						To = model.Email,
						Subject = "Reset Password",
						Body = url
					};
					// 3. Send the email
					EmailSettings.SendEmail(email);
					return RedirectToAction("CheckInbox");
				}
				ModelState.AddModelError(string.Empty, "Try Again Later!");
			}
			return View(model);
		}
		public IActionResult CheckInbox()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ResetPassword(string email, string token)
		{
			TempData["email"] = email;
			TempData["token"] = token;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var email = TempData["email"] as string;
				var token = TempData["token"] as string;
				var user = await userManager.FindByEmailAsync(email);
				if (user is not null)
				{
					var result = await userManager.ResetPasswordAsync(user, token, model.Password);
					if (result.Succeeded)
					{
						return RedirectToAction(nameof(SignIn));
					}
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}

			}
			ModelState.AddModelError(string.Empty, "Please Try Again!");
			return View(model);
		} 
		#endregion

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
