namespace School.Models
{
    public class Grade
    {

        public int StudentId { get; set; }
        public virtual Student Student { get;set; } 
        public int SubjectId { get;set; }   
        public virtual Subject Subject { get;set; } 
        public int total_marks { get; set; }
        
        public Grade()
        {

        }
        public Grade(int StudentId, int SubjectId, int total_marks)
        {
            this.StudentId= StudentId;
            this.SubjectId= SubjectId;
            this.total_marks= total_marks;  
        }
        
    }
}
