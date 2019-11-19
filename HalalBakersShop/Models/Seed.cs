using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HalalBakersShop.Models
{
    public class Seed
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public Seed(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public  void SeedUser()
        {
            if (!_userManager.Users.Any())
            {
                var user = new IdentityUser
                {
                    Email="admin@gmail.com",
                    UserName="Admin@gmail.com"
                };
                var role = new IdentityRole
                {
                    Name = "Admin"
                };
                _roleManager.CreateAsync(role).Wait();
                _userManager.CreateAsync(user, "Admin@123L").Wait();
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
