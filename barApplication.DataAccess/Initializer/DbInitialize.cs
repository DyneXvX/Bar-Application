using System;
using System.Linq;
using BarApplication.DataAccess.Data;
using BarApplication.Models;
using BarApplication.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarApplication.DataAccess.Initializer
{
    public class DbInitialize : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitialize(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0) _db.Database.Migrate();
            }
            catch (Exception ex)
            {
            }

            if (_db.Roles.Any(r => r.Name == Sd.Role_Manager))
            {
                return;
            }
            _roleManager.CreateAsync(new IdentityRole(Sd.Role_Manager)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Sd.Role_Bartender)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Sd.Role_Server)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Sd.Role_Customer)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "manager@outlook.com",
                Email = "manager@outlook.com",
                EmailConfirmed = true,
                Name = "Justin Thoms"
            }, "Password123*").GetAwaiter().GetResult();

            ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "manager@outlook.com");

            _userManager.AddToRoleAsync(user, Sd.Role_Manager).GetAwaiter().GetResult();
        }
    }
}