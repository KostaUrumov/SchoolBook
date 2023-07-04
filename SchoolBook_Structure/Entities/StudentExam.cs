using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolBook_Structure.Entities
{
    public class StudentExam
    {
        public int studentId { get; set; }

        [ForeignKey(nameof(studentId))]
        public Student Student { get; set; } = null!;

        public int ExamId { get; set; }

        [ForeignKey(nameof(ExamId))]
        public Exam Exam { get; set; } = null!;
    }
}
