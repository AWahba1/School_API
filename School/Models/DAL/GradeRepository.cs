
using School.Models.ViewModels;
using System.Data.Entity;

namespace School.Models.DAL
{
    public class GradeRepository: IGradeRepository
    {
        private SchoolContext _schoolContext;
        public GradeRepository(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;    
        }

        public void DeleteGrade(int StudentId, int SubjectId)
        {
            var Grade = _schoolContext.Grade.Find(StudentId, SubjectId);
            if (Grade == null)
            {
                throw new Exception("Student with ID "+StudentId+"isn't enrolled in Subject with ID "+SubjectId);

            }
            _schoolContext.Grade.Remove(Grade);
            _schoolContext.SaveChanges();
        }
        public List<Grade> GetAllGrades()
        {
            // _schoolContext.Database.Log = Console.Write;
            // _schoolContext.Grade.Load();
            // _schoolContext.ChangeTracker.LazyLoadingEnabled = true;

            return _schoolContext.Grade.Include(g => g.Student)
               .Include(g => g.Subject).ToList();

        }

        public Grade GetSpecificGrade(int StudentId, int SubjectId)
        {
            var Grade = _schoolContext.Grade.Find(StudentId, SubjectId);
            return Grade;
        }
        public Grade mapViewModel(GradeViewModel gradeModel)
        {

            return new Grade
            {
                StudentId = gradeModel.StudentId,
                SubjectId = gradeModel.SubjectId,
                total_marks = gradeModel.total_marks
            };
        }

        public void InsertGrade(GradeViewModel gradeModel)
        {
            //validation
            _schoolContext.Grade.Add(mapViewModel(gradeModel));
            _schoolContext.SaveChanges();
        }

        public void UpdateGrade(GradeViewModel gradeVM)
        {
            var Grade = _schoolContext.Grade.Find(gradeVM.StudentId,gradeVM.SubjectId);
            if (Grade == null)
            {
                throw new Exception("Student with ID " + gradeVM.StudentId + "isn't enrolled in Subject with ID " + gradeVM.SubjectId);

            }
            Grade.StudentId = gradeVM.StudentId;
            Grade.SubjectId = gradeVM.SubjectId; 
            Grade.total_marks=gradeVM.total_marks;
            _schoolContext.SaveChanges();
        }

        

        IQueryable<Grade> IGradeRepository.GetStudentGradesAndSubjects(int studentId)
        {
            var grades = _schoolContext.Grade.Where(g => g.StudentId == studentId);
            return grades;
        }
    }
}
