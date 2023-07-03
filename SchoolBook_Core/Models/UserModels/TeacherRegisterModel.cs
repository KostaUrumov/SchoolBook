namespace SchoolBook_Core.Models.UserModels
{
    public class TeacherRegisterModel : RegisterUserModel
    {
        public string Discipline { get; set; } = null!;
    }
}
