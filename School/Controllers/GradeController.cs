using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Models.DAL;
using School.Models.ViewModels;

namespace School.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {

        private readonly IGradeRepository GradeRepository;

        public GradeController()
        {
            this.GradeRepository = new GradeRepository(new SchoolContext());
        }


        [HttpGet] 
        public IActionResult GetAllGrades()
        {
            return Ok(GradeRepository.GetAllGrades());
        }

        [HttpGet("{studentId,subjectId}")]
        //[HttpGet("{studentId/subjectId}")]\
        //[HttpGet]
        public IActionResult GetGrade([FromQuery]int studentId, [FromQuery]int subjectId)
        {
            var grade=GradeRepository.GetSpecificGrade(studentId, subjectId);
            if (grade == null)
                return NotFound("Invalid Student ID or Subject ID or Student isn't enrolled in this course");
            return Ok(grade);
        }

        [HttpPost]
        public IActionResult AddGrade(GradeViewModel gradeModel)
        {
            //validation
            GradeRepository.InsertGrade(gradeModel);
            return Ok(GradeRepository.GetAllGrades());
        }

        [HttpDelete("{studentId,subjectId}")]

        public IActionResult DeleteGrade(int studentId, int subjectId)
        {
            try
            {
                GradeRepository.DeleteGrade(studentId, subjectId);
                return Ok(GradeRepository.GetAllGrades());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateGrade(GradeViewModel gradeVM)
        {
            try
            {
                GradeRepository.UpdateGrade(gradeVM);
                return Ok(GradeRepository.GetAllGrades());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //Find subjects & grades of a specific student
        [HttpGet("Student/{studentId}")]
        public IActionResult GetStudentGradesAndSubjects(int studentId)
        {
            var grades = GradeRepository.GetStudentGradesAndSubjects(studentId);
            return Ok(grades);
        }
    }
}
