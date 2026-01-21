using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }

        public int SrNo { get; set; }
        public string Title { get; set; }

        public int FacultyId { get; set; }
        [ValidateNever]
        public Faculty Faculty { get; set; }
    }

}
