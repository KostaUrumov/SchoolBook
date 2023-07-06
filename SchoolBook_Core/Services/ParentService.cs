using Microsoft.AspNetCore.Identity;
using SchoolBook_Core.Models.ParentModels;
using SchoolBook_Core.Models.StudentModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class ParentService
    {
        private readonly SchoolBookDb data;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public ParentService(SchoolBookDb _data, 
            UserManager<User> _userManager, 
            SignInManager<User> _signInManager, 
            RoleManager<IdentityRole> _roleManager)
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public List<ParentViewModel> GetAllParents()
        {
            List<ParentViewModel> models = data
                .Parents
                .Select(p => new ParentViewModel
                {
                    FirstName = p.User.FirstName,
                    LastName = p.User.LastName,
                    Id = p.Id
                })
                .ToList();
            return models;
        }

        public async Task AddParent(RegisterParentModel model)
        {
            User user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                UserName = model.Username,
                PasswordHash = model.Password.ToString(),
                NormalizedUserName = model.Username.ToUpper()
            };
            await userManager.CreateAsync(user);
            Parent parent = new Parent()
            {
                Id = user.Id,

                MyKids = new List<Student>()
            };
            if (await roleManager.RoleExistsAsync("Parent"))
            {
                await userManager.AddToRoleAsync(user, "Parent");
            }
            await signInManager.SignInAsync(user, isPersistent: false);
            await data.Parents.AddAsync(parent);
            await data.SaveChangesAsync();
        }

        public List<ShowStudentModel> Mykids(string parentId)
        {
            List<ShowStudentModel> listedPeople = data
                .Students
                .Where(s => s.ParentId == parentId)
                .Select(s => new ShowStudentModel
                {
                    Birthday = s.Birthday.Date.ToString(),
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                })
                .ToList();  

            return listedPeople;
        }
    }
}
