using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (_userManager.FindByEmailAsync("usertest@gmail.com").Result == null)
            {
                ApplicationUser user = new ();
                user.UserName = "usersuprem";
                user.Email = "usertest@gmail.com";
                user.NormalizedUserName = "USERSUPREM";
                user.NormalizedEmail = "USERTEST@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "User@2023").Result;
                if (result.Succeeded) 
                {
                    _userManager.AddToRoleAsync(user, Roles.User.ToString()).Wait();
                }
            }
            
            if (_userManager.FindByEmailAsync("admintest@gmail.com").Result == null)
            {
                ApplicationUser user = new ();
                user.UserName = "adminsuprem";
                user.Email = "admintest@gmail.com";
                user.NormalizedUserName = "ADMINSUPREM";
                user.NormalizedEmail = "ADMINTEST@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Admin@2023").Result;
                if (result.Succeeded) 
                {
                    _userManager.AddToRoleAsync(user, Roles.Admin.ToString()).Wait();
                }
            }
        }

        public void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync(Roles.User.ToString()).Result)
            {
                IdentityRole role = new();
                role.Name = Roles.User.ToString();
                role.NormalizedName = Roles.User.ToString().ToUpper();

                _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync(Roles.Admin.ToString()).Result)
            {
                IdentityRole role = new();
                role.Name = Roles.Admin.ToString();
                role.NormalizedName = Roles.Admin.ToString().ToUpper();

                _roleManager.CreateAsync(role);
            }
        }
    }
}
