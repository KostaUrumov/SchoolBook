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
        public async Task AddAdmin(RegisterUserModel model)
        {
            User one = new User();
            one.FirstName = model.FirstName;
            one.LastName = model.LastName;
            one.Email = model.Email;
            one.PasswordHash = model.Password.GetHashCode().ToString();
            one.UserName = model.Username;
            one.NormalizedEmail = model.Email.ToUpper();

            await userManager.CreateAsync(one);
            await data.Users.AddAsync(one);
            await signInManager.SignInAsync(one, isPersistent: false);
            if (one.UserName == "kostadin" && await roleManager.RoleExistsAsync("Admin"))
            {
                await userManager.AddToRoleAsync(one, "Admin");
            }
        }

        public async Task LogIn(LogInViewModel model)
        {
            var user = data.Users.FirstOrDefault(x => x.UserName == model.Username);
            if (user.PasswordHash == model.Password.GetHashCode().ToString())
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }
        }

        public async Task AddTeacher(TeacherRegisterModel model)
        {
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                NormalizedEmail =model.Email.ToUpper(),
                UserName = model.Username,
                PasswordHash = model.Password.GetHashCode().ToString(),
                NormalizedUserName = model.Username.ToUpper()
            };
            await userManager.CreateAsync(user);
            Teacher teacher = new Teacher()
            {
                Discipline = model.Discipline,
                Id = user.Id,
                IsDirector = false,
                MySudents = new List<Student>()
            };

            await data.Teachers.AddAsync(teacher);
            await data.SaveChangesAsync();
        }

    }
}
