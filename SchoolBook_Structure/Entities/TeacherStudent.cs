using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook_Structure.Entities
{
    public class TeacherStudent
    {
        public string TeacherId { get; set; } = null!;

        [ForeignKey(nameof(TeacherId))]
        public User Teacher { get; set; } = null!;

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}
