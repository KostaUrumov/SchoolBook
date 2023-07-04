namespace SchoolBook_Core.Models.UserModels
{
    public class TeacherViewMoodel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string Discipline { get; set; } = null!;

        public bool IsPrincipal { get; set; }
    }
}
