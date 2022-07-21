using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Models.DAL;
using School.Models.ViewModels;

namespace School.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private readonly ISubjectRepository SubjectRepository;

        public SubjectController()
        {
            this.SubjectRepository = new SubjectRepository(new SchoolContext());
        }


        [HttpGet]
        //gets all students
        public IActionResult GetAllSubjects()
        {

            return Ok(SubjectRepository.GetAllSubjects());
        }

        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            var subject = SubjectRepository.GetSubjectById(id);
            if (subject == null)
                return NotFound("There is no Subject with the given ID");
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult AddSubject(SubjectViewModel subjectVM)
        {
            //check if subject data is valid 
            //if not, insert none & output error
            SubjectRepository.InsertSubject(subjectVM);
            return Ok(SubjectRepository.GetAllSubjects());
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSubject(int id)
        {
            try
            {
                SubjectRepository.DeleteSubject(id);
                return Ok(SubjectRepository.GetAllSubjects());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateSubject(SubjectViewModel subjectVM)
        {
            try
            {
                SubjectRepository.UpdateSubject(subjectVM);
                return Ok(SubjectRepository.GetAllSubjects());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        //Find subjects of a specific student
        [HttpGet("Student/{studentId}")]
        public IActionResult GetSubjectsStudentTakes(int studentId)
        {
            var subjects = SubjectRepository.GetSubjectsStudentTakes(studentId);
            return Ok(subjects);
        }





    }
}
