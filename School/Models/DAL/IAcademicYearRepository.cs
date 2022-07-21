using School.Models.ViewModels;

namespace School.Models.DAL
{
    public interface IAcademicYearRepository
    {
        AcademicYear GetAcademicYear(int year);
        void InsertAcademicYear(AcademicYearViewModel AcademicYearVM);
        void DeleteAcademicYear(int year);
        List<AcademicYear> GetAllAcademicYears();
        void UpdateYear(AcademicYearViewModel academicVM);
    }   
}
