using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Models.DAL;
using School.Models.ViewModels;

namespace School.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository StudentRepository;

        public StudentController()
        {
            this.StudentRepository = new StudentRepository(new SchoolContext());
        }


        [HttpGet]
        //gets all students
        public IActionResult GetAllStudents()
        {

            return Ok(StudentRepository.GetAllStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = StudentRepository.GetStudentById(id);
            if (student == null)
                return NotFound("There is no Student with the given ID");
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(StudentViewModel studentVM)
        {
            //check if student data is valid 
            //if not, insert none & output error
            StudentRepository.InsertStudent(studentVM);
            return Ok(StudentRepository.GetAllStudents());
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteStudent(int id)
        {
            try
            {
                StudentRepository.DeleteStudent(id);
                return Ok(StudentRepository.GetAllStudents());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateStudent(StudentViewModel studentVM)
        {
            try
            {
                StudentRepository.UpdateStudent(studentVM);
                return Ok(StudentRepository.GetAllStudents());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Year/{year}")]
        public IActionResult GetStudentsEnrolledInYear(int year)
        {
            var students = StudentRepository.GetStudentsEnrolledInYear(year);
            return Ok(students);
        }






    }
}
