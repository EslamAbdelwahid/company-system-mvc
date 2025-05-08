using Company.Es.DAL.Models;
using Company.Es.PL.ViewModels.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Es.PL.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(string? name)
        {
            var roles = Enumerable.Empty<RoleViewModel>();
            if(!string.IsNullOrEmpty(name))
            {
                roles = await roleManager.Roles.Where(e => e.Name.ToLower().Contains(name.ToLower()))
                    .Select(e => new RoleViewModel()
                    {
                        Id = e.Id,
                        RoleName = e.Name
                    }).ToListAsync();
            }
            else
            {
                roles = await roleManager.Roles.Select(e => new RoleViewModel()
                {
                    Id = e.Id,
                    RoleName = e.Name
                }).ToListAsync();
            }
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    //Id = model.Id, --> مش انا ال بحدده
                    Name = model.RoleName
                };
                var result = await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach(var e in  result.Errors)
                {
                    ModelState.AddModelError(string.Empty, e.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Details(string? id, string ViewName = "Details")
        {
            if (id is null) return BadRequest();
            var role = await roleManager.FindByIdAsync(id);
            if(role is null)
            {
                return NotFound();
            }
            var model = new RoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name
            };
            return View(ViewName, model);
        }
        [HttpGet]
        public async Task<IActionResult >Update(string id)
        {
            return await Details(id, "Update");
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] string id, RoleViewModel model)
        {
            if (id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null) return NotFound();
                role.Name = model.RoleName;
            
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach(var e in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, e.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]string id, RoleViewModel model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            } 
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null) return NotFound();

                var result = await  roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var e in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, e.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrRemoveUsers(string id)
        {
            if (id is null) return BadRequest();
            var users = await userManager.Users.ToListAsync();
            var role = await roleManager.FindByIdAsync(id);
            if (role is null) return NotFound();
            var model = new List<UsersInRoleViewModel>();
            ViewData["RoleId"] = id;
            foreach(var user in users)
            {
                var userInRoleVm = new UsersInRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    userInRoleVm.IsSelected = true;
                }
                else
                {
                    userInRoleVm.IsSelected = false;
                }
                model.Add(userInRoleVm);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUsers(string id, List<UsersInRoleViewModel> model)
        {
            if (id is null) return BadRequest();
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role is null) return NotFound();

                foreach (var user in model)
                {
                    var appUser = await userManager.FindByIdAsync(user.UserId);
                    if(appUser is not null)
                    {
                        if (user.IsSelected && !await userManager.IsInRoleAsync(appUser, role.Name))
                        {
                            await userManager.AddToRoleAsync(appUser, role.Name);
                        }
                        else if(!user.IsSelected && await userManager.IsInRoleAsync(appUser, role.Name))
                        {
                            await userManager.RemoveFromRoleAsync(appUser, role.Name);
                        }
                    }
                }
                return RedirectToAction("Update", new {id = id});
            }
            return View(model);
        }
    }
}
