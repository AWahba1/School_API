using School.Models.ViewModels;

namespace School.Models.DAL
{
    public interface IStudentRepository
    {
        //signatures
        Student GetStudentById(int StudentID);
        void InsertStudent(StudentViewModel studentVM);
        void UpdateStudent(StudentViewModel studentVM);
        void DeleteStudent(int StudentID);
        List<Student> GetAllStudents();
        IQueryable<Student> GetStudentsEnrolledInYear(int year);



    }
}
