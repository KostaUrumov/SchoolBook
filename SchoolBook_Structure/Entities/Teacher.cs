using System.ComponentModel.DataAnnotations;

namespace SchoolBook_Structure.Entities
{
    public class Teacher : User
    {
        [Required]
        public string Discipline { get; set; } = null!;

        public bool IsDirector { get; set; }

        public List<Student> MySudents { get; set; } = new List<Student>();

    }
}
