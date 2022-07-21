namespace School.Models
{
    public class AcademicYearSubject
    {
        public int AcademicYearId { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
