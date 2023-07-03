using Microsoft.AspNetCore.Identity;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class UserService 
    {
        private readonly SchoolBookDb data;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public UserService(SchoolBookDb _data,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        public async Task AddUser(RegisterUserModel model)
        {
            User one = new User();
            if (model.Role == "Principal")
            {
                one.FirstName = model.FirstName;
                one.LastName = model.LastName;
                one.Email = model.Email;
                one.PasswordHash = model.Password.GetHashCode().ToString();
                one.UserName = model.Username;
                one.NormalizedEmail = model.Email.ToUpper();

                
                await userManager.CreateAsync(one);
                await data.Users.AddAsync(one);
                await signInManager.SignInAsync(one, isPersistent: false);

            }

            if (model.Role == "Teacher")
            {
                
                one.FirstName = model.Username;
                one.LastName = model.LastName;
                one.UserName = model.Username;
                one.Email = model.Email;

                await userManager.CreateAsync(one);
                await userManager.AddToRoleAsync(one, "Teacher");
                await data.Users.AddAsync(one);
                await data.SaveChangesAsync();
                await signInManager.SignInAsync(one, isPersistent: false);
               
            }

            if (model.Role == "Parent")
            {
                
                one.FirstName = model.Username;
                one.LastName = model.LastName;
                one.UserName = model.Username;
                one.Email = model.Email;

                await userManager.CreateAsync(one);
                await userManager.AddToRoleAsync(one, "Parent");

                await data.Users.AddAsync(one);
                await data.SaveChangesAsync();
                await signInManager.SignInAsync(one, isPersistent: false);
                
            }
        }

        public async Task AddToRole(string userId, string role)
        {
            User user = data.Users.First(x => x.Id == userId);

            if (await roleManager.RoleExistsAsync(role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

    }
}
