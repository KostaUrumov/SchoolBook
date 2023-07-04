using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Core.Models.StudentModels
{
    public class AddStudentModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public DateTime Birthday { get; set; }
    }
}
