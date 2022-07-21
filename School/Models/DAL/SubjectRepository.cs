using School.Models.ViewModels;

namespace School.Models.DAL
{
    public class SubjectRepository : ISubjectRepository
    {

        public SchoolContext _schoolContext;
        public SubjectRepository(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;
        }
        public void DeleteSubject(int SubjectId)
        {
            var subject = _schoolContext.Subject.Find(SubjectId);
            if (subject == null)
            {
                throw new Exception("There is no Subject with the given ID");

            }
            _schoolContext.Subject.Remove(subject);
            _schoolContext.SaveChanges();
        }

        public List<Subject> GetAllSubjects()
        {
            return _schoolContext.Subject.ToList();
        }

        public Subject GetSubjectById(int SubjectId)
        {
            var subject = _schoolContext.Subject.Find(SubjectId);
            return subject;
        }

        public Subject mapViewModel(SubjectViewModel subjectModel)
        {

            return new Subject
            {
                SubjectId = subjectModel.SubjectId,
                SubjectName = subjectModel.SubjectName
            };
        }

        public void InsertSubject(SubjectViewModel subjectVM)
        {
            _schoolContext.Subject.Add(mapViewModel(subjectVM));
            _schoolContext.SaveChanges();
        }

        public void UpdateSubject(SubjectViewModel subjectVM)
        {
            var subj = _schoolContext.Subject.Find(subjectVM.SubjectId);
            if (subj == null)
            {
                throw new Exception("There is no Subject with the given ID");

            }
            subj.SubjectName= subjectVM.SubjectName;
            _schoolContext.SaveChanges();
        }

        public IQueryable<Subject> GetSubjectsStudentTakes(int studentId)
        {
            var subjects = from grade in _schoolContext.Grade
                           join student in _schoolContext.Student
                           on grade.StudentId equals studentId
                           join subject in _schoolContext.Subject
                           on grade.SubjectId equals subject.SubjectId
                           select new Subject
                           {
                               SubjectId=grade.SubjectId,
                               SubjectName=subject.SubjectName
                           };
            return subjects.Distinct(); //remove dups
        }
    }
}
