namespace School.Models
{
    public class AcademicYear
    {
        public int AcademicYearId { get; set; } //year
        public int? Duration { get; set; }
        public String StartMonth { get; set; }
        public String EndMonth { get;set; }
        public ICollection<Student> Students { get; set; }
        
        public AcademicYear()
        {
            
        }
        public AcademicYear(int year)
        {
            this.AcademicYearId = year;
        }


    }
}
