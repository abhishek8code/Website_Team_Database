using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class TrainingAndWorkshop
    {
        public int TrainingAndWorkshopId { get; set; }

        public string Title { get; set; }
        public string OrganizedBy { get; set; }
        public string Date { get; set; }

        public int FacultyId { get; set; }
        [ValidateNever]
        public Faculty Faculty { get; set; }
    }

}
