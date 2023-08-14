using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StockMgtApp.Pages.Logic
{
    public class RoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
           
        }
        
       /* public List<IdentityRole> OnGet()
        {
            var roles = _roleManager.Roles.ToList();
            return roles;
        }*/

        public IdentityRole OnGet()
        {
            return new IdentityRole();
        }

        /*public async Task<IActionResult> OnCreate(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }*/
    }
}
