using School.Models.ViewModels;

namespace School.Models.DAL
{
    public class StudentRepository:IStudentRepository
    {
        public SchoolContext _schoolContext;
        public StudentRepository(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;
        }

        public Student GetStudentById(int StudentId)
        {
            var student = _schoolContext.Student.Find(StudentId);
            return student;
        }
        public List<Student> GetAllStudents()
        {
            return _schoolContext.Student.ToList();
        }

        public Student mapViewModel(StudentViewModel studentVM)
        {

            return new Student
            {
                StudentId = studentVM.StudentId,
                FirstName = studentVM.FirstName,
                LastName = studentVM.LastName,
                YearOfBirth = studentVM.YearOfBirth,
                
            };
        }

        public void InsertStudent(StudentViewModel studentVM)
        {
            _schoolContext.Student.Add(mapViewModel(studentVM));
            _schoolContext.SaveChanges();
        }

       

        void IStudentRepository.DeleteStudent(int StudentId)
        {
            var student = _schoolContext.Student.Find(StudentId);
            if (student == null)
            {
                throw new Exception("There is no Student with the given ID");

            }
            _schoolContext.Student.Remove(student);
            _schoolContext.SaveChanges();
        }

       

        void IStudentRepository.UpdateStudent(StudentViewModel studentVM)
        {
            var stud = _schoolContext.Student.Find(studentVM.StudentId);
            if (stud == null)
            {
                throw new Exception("Invalid Student ID.");

            }
          
            stud.FirstName= studentVM.FirstName;
            stud.LastName= studentVM.LastName;
            stud.YearOfBirth = studentVM.YearOfBirth;
            _schoolContext.SaveChanges();
        }

        IQueryable<Student> IStudentRepository.GetStudentsEnrolledInYear(int year)
        {
            var students = _schoolContext.Student.Where(s => s.AcademicYear.AcademicYearId == year);
            return students;
        }




    }

        
    
}
