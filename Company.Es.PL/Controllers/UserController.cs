using AutoMapper;
using Company.Es.DAL.Models;
using Company.Es.PL.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Es.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
			this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index(string InputSearch)
		{
            var userQuery = userManager.Users.AsQueryable();
            if (!string.IsNullOrEmpty(InputSearch))
            {
                userQuery = userQuery.Where(u => u.Email.ToLower().Contains(InputSearch.ToLower()));
            }
            var users = await userQuery.ToListAsync();
            List<UserViewModel> model = new List<UserViewModel>();
            foreach(var user in users)
            {
                UserViewModel userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = await userManager.GetRolesAsync(user)
                };
                model.Add(userViewModel);
            }
			return View(model);
		}

		public async Task<IActionResult> Details(string? Id, string ViewName = "Details")
		{
			if (Id is null) return BadRequest();
			var user = await userManager.FindByIdAsync(Id);
			if(user is null) return NotFound();
			var userVM = mapper.Map<UserViewModel>(user);
			return View(ViewName, userVM);
		}

		[HttpGet]
		public async Task<IActionResult> Update(string? Id)
		{
			return await Details(Id, "Update");
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, UserViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(id);
                if (user is null) return NotFound();

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;

                var res = await userManager.UpdateAsync(user);
                if (!res.Succeeded)
                {
                    // Handle errors if needed
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

		public async Task<IActionResult> Delete(string? id)
		{
			if(id is null) return BadRequest();
			var user = await userManager.FindByIdAsync(id);
			if (user is null) return NotFound();
		    var result = await userManager.DeleteAsync(user);
			return RedirectToAction("Index");	
		}
    }
}
