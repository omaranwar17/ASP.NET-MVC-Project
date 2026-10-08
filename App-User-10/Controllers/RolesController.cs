using APP_DATA_A_10.Models.Auth_User;
using App_User_10.ViewModels.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_User_10.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roles;
        private readonly UserManager<AppUser> _users;
        public RolesController(RoleManager<IdentityRole> roles , UserManager<AppUser> users)
        {
            _roles = roles;
            _users = users;

        }
        public IActionResult Index(string searchName)
        {
            var roles = new List<RoleViewM>();

            if (string.IsNullOrEmpty(searchName))
            {
                roles = _roles.Roles.Select(r => new RoleViewM()
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList();

            }
            else
            {
                roles = _roles.Roles.Where(r => r.NormalizedName.Contains(searchName.ToUpper())).Select(r => new RoleViewM()
                {
                    Id = r.Id,
                    Name = r.Name
                }).ToList();


            }

            return View(roles);


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewM model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = model.Name };
                var result = await _roles.CreateAsync(role);

                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(string id ,  string viewName = "Details")
        {
            if (id == null) return BadRequest();
            var role = _roles.FindByIdAsync(id).Result;
            if (role == null) return NotFound();
       
            var viewM = new RoleViewM()
            {
                Id = role.Id,
                Name = role.Name
            };

            return View(viewName , viewM);
        }


        [HttpGet] 
        public IActionResult Edit(string id)
        {
            return Details(id, "Edit");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] string? id, RoleViewM model)
        {
            if (id == null || id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var rolr = _roles.FindByIdAsync(id).Result;
                if (rolr == null) return NotFound();
                rolr.Name = model.Name;
                var result = _roles.UpdateAsync(rolr).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty , item.Description);    
                    }
                }
            }
            return View(model);

        }


        [HttpGet]
        public IActionResult Delete(string? id)
        {
            return Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]string? id , RoleViewM model)
        {
            if (id == null || id != model.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var role = _roles.FindByIdAsync(id).Result;
                if (role == null) return NotFound();
                var result = _roles.DeleteAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty , item.Description);
                    }
                }

            }


            return View(model);
        }


        [HttpGet]
        public IActionResult AddOrRemoveUsers(string? roleId)
        {
            if (roleId == null) return BadRequest();
            var role = _roles.FindByIdAsync(roleId).Result;
            if (role == null) return NotFound();
            ViewData["RoleId"] = roleId;
            var usersInRole = new List<UserInRoleViewM>();
            var users = _users.Users.ToList();
            foreach (var item in users)
            {
                var userInRole = new UserInRoleViewM()
                {
                   UserId = item.Id,
                   UserName = item.UserName,
  
                };
                if (_users.IsInRoleAsync(item, role.Name).Result)
                {
                    userInRole.IsSelected = true;
                }
                else
                {
                    userInRole.IsSelected = false;
                }
                usersInRole.Add(userInRole);
            }
            return View(usersInRole);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrRemoveUsers(string? roleId, List<UserInRoleViewM> model)
        {
            if (roleId == null) return BadRequest();
            var role = _roles.FindByIdAsync(roleId).Result;
            if (role == null) return NotFound();
            if (ModelState.IsValid)
            {
                bool flag = true;
                IdentityResult result = null;
                foreach (var user in model)
                {
                  var appUser = _users.FindByIdAsync(user.UserId).Result;
                    if (appUser != null)
                    {
                        if (user.IsSelected && !_users.IsInRoleAsync(appUser, role.Name).Result)
                        {
                         result = _users.AddToRoleAsync(appUser, role.Name).Result;
                        }
                        else if (!user.IsSelected && _users.IsInRoleAsync(appUser, role.Name).Result)
                        {
                           result = _users.RemoveFromRoleAsync(appUser, role.Name).Result;
                        }
                        if (result != null && !result.Succeeded)
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                            flag = false;  
                            result = null;
                        }
                    }

                   
                }
                if (flag)
                {
                    return RedirectToAction(nameof(Edit) , new {id = roleId});
                }
            }
            return View(model);

        }
    }
}
