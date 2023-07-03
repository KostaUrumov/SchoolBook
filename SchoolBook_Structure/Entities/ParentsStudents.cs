using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook_Structure.Entities
{
    public class ParentsStudents
    {
        public string ParentId { get; set; } = null!;

        [ForeignKey(nameof(ParentId))]
        public User Parent { get; set; } = null!;

        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; } = null!;
    }
}
