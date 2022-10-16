using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AllasController : Controller
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _db;

        public AllasController(UserManager<SiteUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
        [HttpPost]

        public IActionResult Add(Allas allas)
        {
            allas.UID = Guid.NewGuid().ToString();
            allas.Jelentkezok = new List<SiteUser>();
            _db.Allasok.Add(allas);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult>Jelentkezes(string uid)
        {
            
            var user = await _userManager.GetUserAsync(this.User);
            _db.Allasok.FirstOrDefault(t => t.UID == uid)?.Jelentkezok.Add(user);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View(_db.Allasok);
        }

        public async Task<IActionResult> DelegateAdmin()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(role);
            }
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Users));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GrantAdmin(string uid)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Id == uid);
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction(nameof(Users));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
    }
}
