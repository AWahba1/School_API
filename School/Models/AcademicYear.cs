namespace School.Models
{
    public class AcademicYear
    {
        public int AcademicYearId { get; set; } //year
        public ICollection<Student> Students { get; set; }
        public ICollection<AcademicYearSubject>? AcademicYearSubjects { get; set; }


    }
}
