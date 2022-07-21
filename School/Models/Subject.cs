namespace School.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public ICollection<Grade>? Grades { get; set; }
        

    }
}
