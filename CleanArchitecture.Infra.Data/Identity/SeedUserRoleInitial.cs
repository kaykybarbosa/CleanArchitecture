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

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usertest@gmail.com").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "usersuprem",
                    Email = "usertest@gmail.com",
                    NormalizedUserName = "USERSUPREM",
                    NormalizedEmail = "USERTEST@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "User@2023").Result;
                if (result.Succeeded) 
                {   
                    _userManager.AddToRoleAsync(user, Roles.User).Wait();
                }
            }
            
            if (_userManager.FindByEmailAsync("admintest@gmail.com").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "adminsuprem",
                    Email = "admintest@gmail.com",
                    NormalizedUserName = "ADMINSUPREM",
                    NormalizedEmail = "ADMINTEST@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = _userManager.CreateAsync(user, "Admin@2023").Result;
                if (result.Succeeded) 
                {
                    _userManager.AddToRoleAsync(user, Roles.Admin).Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync(Roles.User).Result)
            {
                IdentityRole role = new()
                {
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                };

                _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync(Roles.Admin).Result)
            {
                IdentityRole role = new()
                {
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                };

                _roleManager.CreateAsync(role);
            }
        }
    }
}
