using Microsoft.AspNetCore.Identity;
using SchoolBook_Core.Contracts;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class UserService : IUser
    {
        private readonly SchoolBookDb data;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        
        public UserService(SchoolBookDb _data,
            UserManager<User> _userManager,
            SignInManager<User> _signInManager)
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
            
        }
        public async Task AddUser(RegisterUserModel model)
        {
            if (model.Role == "Principal")
            {
                User one = new User
                {
                    FirstName = model.Username,
                    LastName = model.LastName,
                    UserName = model.Username,
                    Email = model.Email,
                   
                };
                await userManager.CreateAsync(one);
                await userManager.AddToRoleAsync(one, "Principal");

                await data.Users.AddAsync(one);
                await data.SaveChangesAsync();

                await signInManager.SignInAsync(one, isPersistent: false);
            }

            if (model.Role == "Teacher")
            {
                User one = new User
                {
                    FirstName = model.Username,
                    LastName = model.LastName,
                    UserName = model.Username,
                    Email = model.Email,

                };
                await userManager.CreateAsync(one);
                await userManager.AddToRoleAsync(one, "Teacher");

                await data.Users.AddAsync(one);
                await data.SaveChangesAsync();

                await signInManager.SignInAsync(one, isPersistent: false);
            }

            if (model.Role == "Parent")
            {
                User one = new User
                {
                    FirstName = model.Username,
                    LastName = model.LastName,
                    UserName = model.Username,
                    Email = model.Email,

                };
                await userManager.CreateAsync(one);
                await userManager.AddToRoleAsync(one, "Parent");

                await data.Users.AddAsync(one);
                await data.SaveChangesAsync();

                await signInManager.SignInAsync(one, isPersistent: false);
            }
        }
    }
}
