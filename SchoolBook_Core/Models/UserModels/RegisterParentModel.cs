using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Models.UserModels
{
    public class RegisterParentModel : RegisterUserModel
    {
        public List<Student>? MyKids { get; set; } = new List<Student>();
    }
}
