using Microsoft.AspNetCore.Identity;
using SchoolBook_Core.Models.StudentModels;
using SchoolBook_Core.Models.Teacher;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;
using System.ComponentModel;

namespace SchoolBook_Core.Services
{
    public class TeacherService
    {
        private readonly SchoolBookDb data;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TeacherService(
            SchoolBookDb _data, 
            SignInManager<User> _signInManager, 
            UserManager<User> _userManager,
            RoleManager<IdentityRole> _roleManager)
        {
            data = _data;
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
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
                    IsPrincipal = t.IsDirector,
                    Id = t.Id,
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
            if (await roleManager.RoleExistsAsync("Teacher"))
            {
                await userManager.AddToRoleAsync(user, "Teacher");
            }
            
            await data.Teachers.AddAsync(teacher);
            await data.SaveChangesAsync();
        }

        public async Task RemovePrincipal()
        {
            foreach (Teacher item in data.Teachers)
            {
                if (item.IsDirector == true)
                {
                    item.IsDirector = false;
                }
            }
            await data.SaveChangesAsync();
        }

        public async Task BecomePrincipal(string userId)
        {
            Teacher tech = data.Teachers.First(x => x.Id == userId);
            tech.IsDirector = true;
            await data.SaveChangesAsync();
        }

        public async Task AddToMyClass(string userId, int studentId)
        {
            Teacher teacher = data.Teachers.First(y => y.Id == userId);
            Student stud = data.Students.First(s => s.studentId == studentId);
            TeacherStudent teachStudent = new TeacherStudent()
            {
                TeacherId = teacher.Id,
                StudentId = studentId,
            };
            await data.TeacherStudents.AddAsync(teachStudent);
            await data.SaveChangesAsync();
        }

        public List<ShowStudentModel> MyClass(string userId)
        {
            Teacher teacher = data.Teachers.First(y => y.Id == userId);
            List<ShowStudentModel> myclass = data
                .TeacherStudents
                .Where(t=>t.TeacherId == teacher.Id)
                .Select(t => new ShowStudentModel()
                {
                    FirstName = t.Student.FirstName,
                    LastName = t.Student.LastName,
                    Birthday = t.Student.Birthday.Date.ToShortDateString(),
                    Id = t.StudentId

                })
                .ToList();

            return myclass;
        }

        public async Task RemoveFromClass(string userId, int studentId)
        {
            List<TeacherStudent> toBeRemoved = data
                .TeacherStudents
                .Where(t=>t.TeacherId == userId)
                .Where(s=>s.StudentId == studentId)
                .ToList();

             data.TeacherStudents.RemoveRange(toBeRemoved);
             await data.SaveChangesAsync();


        }

        public bool CheckIfThere(string userId, int studentId)
        {
            Teacher teacher = data.Teachers.First(y => y.Id == userId);
            Student stud = data.Students.First(s => s.studentId == studentId);
            TeacherStudent teachStudent = new TeacherStudent()
            {
                TeacherId = teacher.Id,
                StudentId = studentId,
            };
            if (data.TeacherStudents.Contains(teachStudent))
            {
                return true;
            }
            return false;
        }

        public List<ShowStudentModel> FindStudents(int examId)
        {
            Exam exam = data.Exams.First(x => x.Id == examId);
            List<ShowStudentModel> students = new List<ShowStudentModel>();
            foreach (var student in data.Students)
            {
                if (!student.Exams.Contains(exam))
                {
                    ShowStudentModel studentModel = new ShowStudentModel()
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Birthday = student.Birthday.ToShortDateString(),
                        ExamId = exam.Id,
                        Id = student.studentId
                    };
                    students.Add(studentModel);
                }
            }
                
            return students;
        }

        public bool IfStudentIsAssigned(int examId, int studentId)
        {
            Exam exam = data.Exams.First(x => x.Id == examId);
            Student stud = data.Students.First(s => s.studentId == studentId);
            StudentExam newStudentExam = new StudentExam()
            {
                StudentId = studentId,
                ExamId = examId
            };
            if (data.StudentsExams.Contains(newStudentExam))
            {
                return true;
            }
            return false;

        }

        public void AddToExam(int examId, int studentId)
        {
            StudentExam newStudentExam = new StudentExam()
            {
                StudentId = studentId,
                ExamId = examId
            };

            data.StudentsExams.Add(newStudentExam);
            data.SaveChanges();
        }

        

    }
}
