using SchoolBook_Core.Models.UserModels;

namespace SchoolBook_Core.Models.Teacher
{
    public class TeacherRegisterModel : RegisterUserModel
    {
        public string Discipline { get; set; } = null!;
    }
}
