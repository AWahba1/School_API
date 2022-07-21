namespace School.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int YearOfBirth { get; set; }



        //public int? AcademicYearId { get; set; }
        public virtual AcademicYear? AcademicYear { get; set; }
        public ICollection<Grade>? Grades { get; set; }


    }
}
