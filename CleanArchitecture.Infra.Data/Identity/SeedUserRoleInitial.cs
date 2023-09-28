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

        public async Task SeedUsers()
        {
            if (_userManager.FindByEmailAsync("userdefault@gmail.com").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "userDefault",
                    Email = "userdefault@gmail.com",
                    NormalizedUserName = "USERSUPREM",
                    NormalizedEmail = "USERDEFAULT@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = await _userManager.CreateAsync(user, "@UserDefault123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User);
                }
            }

            if (_userManager.FindByEmailAsync("superadmin@gmail.com").Result == null)
            {
                ApplicationUser user = new()
                {
                    UserName = "superadmin",
                    Email = "superadmin@gmail.com",
                    NormalizedUserName = "ADMINSUPREM",
                    NormalizedEmail = "ADMINTEST@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = await _userManager.CreateAsync(user, "Admin@2023");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Admin);
                }
            }
        }

        public async Task SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync(Roles.User).Result)
            {
                IdentityRole role = new()
                {
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                };

                await _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync(Roles.Admin).Result)
            {
                IdentityRole role = new()
                {
                    Name = Roles.Admin,
                    NormalizedName = Roles.Admin.ToUpper()
                };

                await _roleManager.CreateAsync(role);
            }
        }
    }
}
