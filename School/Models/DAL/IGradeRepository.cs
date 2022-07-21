using School.Models.ViewModels;

namespace School.Models.DAL
{
    public interface IGradeRepository
    {
        List<Grade>GetAllGrades();
        Grade GetSpecificGrade(int StudentId, int SubjectId);
        void UpdateGrade(GradeViewModel gradeVM);
        void DeleteGrade(int StudentId, int SubjectId);
        void InsertGrade(GradeViewModel gradeModel);

        IQueryable<Grade> GetStudentGradesAndSubjects(int studentId);
    }
}
