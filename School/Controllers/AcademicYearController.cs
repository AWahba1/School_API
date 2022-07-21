using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Models.DAL;
using School.Models.ViewModels;

namespace School.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearRepository AcademicYearRepository;
        public AcademicYearController()
        {
            this.AcademicYearRepository = new AcademicYearRepository(new SchoolContext());
        }

        [HttpGet]
        public IActionResult GetAllYears()
        {
            return Ok(AcademicYearRepository.GetAllAcademicYears());

        }
        [HttpGet("{year}")]
        public IActionResult GetSpecificYear(int year)
        {
            var AcademicYear=AcademicYearRepository.GetAcademicYear(year);
            if (AcademicYear == null)
                return NotFound("Academic year doesn't exist");
            return Ok(AcademicYear);    
        }

        [HttpPost]
        public IActionResult AddAcademicYear(AcademicYearViewModel AcademicYearVM)
        {   
            //validity
            AcademicYearRepository.InsertAcademicYear(AcademicYearVM);
            return Ok(AcademicYearRepository.GetAllAcademicYears());
        }

        [HttpDelete("{year}")]
        public IActionResult DeleteAcademicYear(int year)
        {
            try
            {
                AcademicYearRepository.DeleteAcademicYear(year);
                return Ok(AcademicYearRepository.GetAllAcademicYears());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);  
            }
            
        }


        [HttpPut]
        public IActionResult UpdateYear(AcademicYearViewModel academicVM)
        {
            try
            {
                AcademicYearRepository.UpdateYear(academicVM);
                return Ok(AcademicYearRepository.GetAllAcademicYears());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



    }
}
