namespace SchoolBook_Structure.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public string Disciplibe { get; set; } = null!;

        public DateTime ExamDate { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

    }
}
