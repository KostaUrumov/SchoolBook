using SchoolBook_Core.Models.ExamModels;
using SchoolBook_Core.Models.StudentModels;
using SchoolBook_Structure.Data;
using SchoolBook_Structure.Entities;

namespace SchoolBook_Core.Services
{
    public class ExamService
    {
        private readonly SchoolBookDb data;
        public ExamService(SchoolBookDb _data)
        {
            data = _data;
        }

        public async Task AddExam(AddExamModel model)
        {
            Exam exam = new Exam()
            {
                Disciplibe = model.Disciplibe,
                ExamDate = model.ExamDate,
                Students = new List<Student>()
           };

            await data.Exams.AddAsync(exam);
            await data.SaveChangesAsync();
        }

        public List<ShowExamModel> AllExams()
        {
            List<ShowExamModel> exams = data
                .Exams
                .Select(x => new ShowExamModel() 
                {
                    Date = x.ExamDate.Date.ToString(),
                    Discimpline = x.Disciplibe,
                    Id= x.Id
                })
                .ToList();

            return exams;
        }

        public async Task AddStudentsToTheExam(string userId, AddExamModel model)
        {
            Teacher teacher = data.Teachers.First(y => y.Id == userId);
            List<Exam> exam = data.Exams
                .Where(e => e.Disciplibe == model.Disciplibe)
                .Where(e => e.ExamDate == model.ExamDate)
                .ToList();

            List<Student> students = data
                .TeacherStudents
                .Where(t => t.TeacherId == teacher.Id)
                .Select(f=>f.Student)
                .ToList();
            List<StudentExam> studExams = new List<StudentExam>();
            foreach (Student student in students)
            {
                StudentExam sE = new StudentExam()
                {
                    ExamId = exam[0].Id,
                    StudentId = student.studentId
                };
                studExams.Add(sE);
            }

            await data.StudentsExams.AddRangeAsync(studExams);
            await data.SaveChangesAsync();
           
            
        }

        public List<ShowStudentModel> CheckParticipants(int examId)
        {
            List<ShowStudentModel> students = data
                .StudentsExams
                .Where(e => e.ExamId == examId)
                .Select(s => new ShowStudentModel()
                {
                    FirstName = s.Student.FirstName,
                    LastName = s.Student.LastName,
                    Birthday = s.Student.Birthday.ToShortDateString()
                })
                .ToList();
            return students;
        }

    }
}
