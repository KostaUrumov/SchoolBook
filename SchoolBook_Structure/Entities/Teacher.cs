using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook_Structure.Entities
{
    public class Teacher
    {
        [Required]
        public string Id { get; set; } = null!;

        [ForeignKey(nameof(Id))]
        public User User { get; set; } = null!;
        public string? Discipline { get; set; }

        public bool IsDirector { get; set; }

        public List<Student> MySudents { get; set; } = new List<Student>();

    }
}
