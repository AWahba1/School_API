using School.Models.ViewModels;

namespace School.Models.DAL
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private SchoolContext _schoolContext;
        public AcademicYearRepository(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;
        }

        public void DeleteAcademicYear(int year)
        {
            var AcademicYear = _schoolContext.AcademicYear.Find(year);
            if (AcademicYear == null)
                throw new Exception("Year provided doesn't exist");
            _schoolContext.AcademicYear.Remove(AcademicYear);
            _schoolContext.SaveChanges();
        }

        public AcademicYear GetAcademicYear(int year)
        {
            var AcademicYear = _schoolContext.AcademicYear.Find(year);
            return AcademicYear;
        }

        public List<AcademicYear> GetAllAcademicYears()
        {
            return _schoolContext.AcademicYear.ToList();
        }

        public AcademicYear mapViewModel(AcademicYearViewModel AcademicYearVM)
        {

            return new AcademicYear
            {
                AcademicYearId = AcademicYearVM.AcademicYearId,
                Duration = AcademicYearVM.Duration,
                StartMonth = AcademicYearVM.StartMonth,
                EndMonth = AcademicYearVM.EndMonth
            };
        }
        public void InsertAcademicYear(AcademicYearViewModel AcademicYearVM)
        {
            // check if it's valid
            _schoolContext.Add(mapViewModel(AcademicYearVM));
            _schoolContext.SaveChanges();

        }

        public void UpdateYear(AcademicYearViewModel AcademicYearVM)
            {
            var academicYears = _schoolContext.AcademicYear.Find(AcademicYearVM.AcademicYearId);
            if (academicYears == null)
            {
                throw new Exception("Academic Year doesn't exist");

            }

            academicYears.StartMonth= AcademicYearVM.StartMonth;
            academicYears.EndMonth= AcademicYearVM.EndMonth;
            academicYears.Duration= AcademicYearVM.Duration;


            _schoolContext.SaveChanges();
        }

    }
}
