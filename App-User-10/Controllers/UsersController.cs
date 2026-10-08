using APP_DATA_A_10.Models.Auth_User;
using App_User_10.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_User_10.Controllers
{
    [Authorize(Roles = "Admin")]

    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        //[HttpGet]
        //public async Task<IActionResult> Index(string? searchName)
        //{
        //    var users = new List<UsersViewM>();

        //    var query = _userManager.Users.AsQueryable();
        //    if (!string.IsNullOrEmpty(searchName))
        //    {
        //        query = query.Where(u => u.NormalizedEmail.Contains(searchName.ToUpper()));
        //    }

        //    var userEntities = query.ToList();

        //    foreach (var u in userEntities)
        //    {
        //        var roles = await _userManager.GetRolesAsync(u);
        //        users.Add(new UsersViewM
        //        {
        //            Id = u.Id,
        //            Email = u.Email,
        //            FName = u.FName,
        //            LName = u.LName,
        //            PhoneNumber = u.PhoneNumber,
        //            Roles = roles
        //        });
        //    }

        //    return View(users);
        //}

        [HttpGet]
        public async Task<IActionResult> Index(string? searchName)
        {
            var query = _userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                var normalized = searchName.Trim().ToUpperInvariant();
                query = query.Where(u => u.NormalizedEmail != null && u.NormalizedEmail.Contains(normalized));
            }

            var userEntities = await query.ToListAsync();

            var users = new List<UsersViewM>();
            foreach (var u in userEntities)
            {
                var roles = await _userManager.GetRolesAsync(u);
                users.Add(new UsersViewM
                {
                    Id = u.Id,
                    Email = u.Email,
                    FName = u.FName,
                    LName = u.LName,
                    PhoneNumber = u.PhoneNumber,
                    Roles = roles
                });
            }

            ViewData["searchName"] = searchName;
            return View(users);
        }


        [HttpGet]
        [Route("Users/Details/{id}")]
        public async Task<IActionResult> Details(string? id , string viewName = "Details")
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            var viewModel = new UsersViewM
            {
                Id = user.Id,
                Email = user.Email,
                FName = user.FName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                Roles = await _userManager.GetRolesAsync(user)
            };

            return View(viewName, viewModel);
        }


     
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            return await Details(id, "Edit");

        }

        //[HttpPost]
        //public async Task<IActionResult> Edit([FromRoute]string? id, UsersViewM model)
        //{
        //    if (id == null || id != model.Id) return BadRequest();

        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByIdAsync(id);
        //        if (user == null) return NotFound();

        //        user.FName = model.FName;
        //        user.LName = model.LName;
        //        user.Email = model.Email;

        //        var result = await _userManager.UpdateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            foreach (var err in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, err.Description);

        //            }
        //        }



        //    }

        //    return View(model);

        //}



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string? id, UsersViewM model)
        {
            if (id == null || id != model.Id) return BadRequest();

            ModelState.Remove(nameof(model.Roles));

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound();

                user.FName = model.FName;
                user.LName = model.LName;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            return await Details(id, "Delete");

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete([FromRoute]string? id, UsersViewM model)
        //{
        //    if (id == null || id != model.Id) return BadRequest();
            

        //    if (ModelState.IsValid)
        //    {
        //        var user = _userManager.FindByIdAsync(id).Result;
        //        if (user == null) return NotFound();
        //        var result = _userManager.DeleteAsync(user).Result;
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            foreach (var item in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, item.Description);
        //            }
        //        }
        //    }
        //    return View(model);

        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string? id, UsersViewM model)
        {
            if (string.IsNullOrWhiteSpace(id) || id != model.Id)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            // نمسح أخطاء الحقول اللي ماتبعتتش ونعرض أخطاء Identity بس
            ModelState.Clear();
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

    }
}
