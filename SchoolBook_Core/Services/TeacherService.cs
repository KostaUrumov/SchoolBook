using Microsoft.AspNetCore.Identity;
using SchoolBook_Core.Models.UserModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class TeacherService
    {
        private readonly SchoolBookDb data;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public TeacherService(SchoolBookDb _data, SignInManager<User> _signInManager, UserManager<User> _userManager)
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public List<TeacherViewMoodel> GetAllTeachers()
        {
            List<TeacherViewMoodel> teachers = data
                .Teachers
                .Select(t => new TeacherViewMoodel
                {
                    FirstName = t.User.FirstName,
                    LastName = t.User.LastName,
                    Discipline = t.Discipline,
                    IsPrincipal = t.IsDirector
                })
                .ToList();

            return teachers;
        }

        public async Task AddTeacher(TeacherRegisterModel model)
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
