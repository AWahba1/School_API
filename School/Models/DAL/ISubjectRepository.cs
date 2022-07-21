using School.Models.ViewModels;

namespace School.Models.DAL
{
    public interface ISubjectRepository
    {
        Subject GetSubjectById(int SubjectId);
        void InsertSubject(SubjectViewModel subjectVM);
        void UpdateSubject(SubjectViewModel subjectVM);
        void DeleteSubject(int SubjectId);
        List<Subject> GetAllSubjects();
        IQueryable<Subject> GetSubjectsStudentTakes(int studentId);
    }
}
