using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourismWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace TourismWebsite.Controllers
{
    [Authorize(Roles = "Administrator, User")]
   

    public class RolesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        [Authorize(Roles = "Administrator, User")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleName")] Role role)
        {

            if (ModelState.IsValid)
            {


                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }

                string errors = "";

                foreach (IdentityError error in result.Errors)
                {
                    errors += error.Description + "\n";
                }

                return Content("An error occurred. \n" + errors);
                //return View(role);

            }
            else
            {

                return View(role);
            }
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {

            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ManageUsers(string id)
        {

            IdentityRole role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {

                return RedirectToAction("Index");
            }

            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonmembers = new List<IdentityUser>();

            foreach (IdentityUser currentUser in userManager.Users.ToList())
            {

                if (await userManager.IsInRoleAsync(currentUser, role.Name))
                {

                    members.Add(currentUser);
                }
                else
                {
                    nonmembers.Add(currentUser);
                }
            }

            RoleManagement model = new RoleManagement
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }

        [Route("RolesController/AddMemberToRole/{userId}/{roleId}")]
        public async Task<IActionResult> AddMemberToRole(string userId, string roleId)
        {

            IdentityUser user = await userManager.FindByIdAsync(userId);
            IdentityRole roleName = await roleManager.FindByIdAsync(roleId);

            await userManager.AddToRoleAsync(user, roleName.Name);

            return RedirectToAction("ManageUsers");
        }

        [Route("RolesController/RemoveMemberFromRole/{userId}/{roleId}")]
        public async Task<IActionResult> RemoveMemberFromRole(string userId, string roleId)
        {

            IdentityUser user = await userManager.FindByIdAsync(userId);
            IdentityRole roleName = await roleManager.FindByIdAsync(roleId);

            await userManager.RemoveFromRoleAsync(user, roleName.Name);

            //return Content("UserID = " + userId + " RoleID = " + roleId);
            return RedirectToAction("ManageUsers");
        }



        //edit

        /*
        public async Task<IActionResult> Edit(string id, [Bind("RoleName")] Role role)
        {

            
            //await roleManager.DeleteAsync(roleObj);



            if (ModelState.IsValid)
            {
                IdentityRole roleOld = await roleManager.FindByIdAsync(id);
                var oldRoleId = roleOld.Id;


                IdentityResult result = await roleManager.UpdateAsync(new IdentityRole(role.RoleName));

                if (result.Succeeded)
                {

                    return RedirectToAction("Index");
                }

                string errors = "";

                foreach (IdentityError error in result.Errors)
                {
                    errors += error.Description + "\n";
                }

                return Content("An error occurred. \n" + errors);
                return View(role);

            }
            
        }
        */
    }
}