using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GECPATAN_FACULTY_PORTAL.Models
{
    public class CampusCommittee : BaseEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? TitleImage { get; set; }
        public string? TitleImageCSSClass { get; set; }
        public string? About { get; set; }
        public string? Measures { get; set; }
        public string? Measure_Image { get; set; }
        public string? SubObjImg { get; set; }
        public string? BulletPointsImg { get; set; }
        public string? PageFlyer { get; set; }
        public string? Tagline { get; set; }
        public string? BlogLink { get; set; }
        public string? Link { get; set; }
        public bool ShowDocument { get; set; }
        public bool TableView { get; set; }

        /* Navigation */
        [ValidateNever]
        public ICollection<CommitteeVision> Visions { get; set; }
        [ValidateNever]
        public ICollection<CommitteeMission> Missions { get; set; }
        [ValidateNever]
        public ICollection<CommitteeObjective> Objectives { get; set; }
        [ValidateNever] 
        public ICollection<CommitteeSubObjective> SubObjectives { get; set; }
        [ValidateNever]
        public ICollection<CommitteeMember> Members { get; set; }
        [ValidateNever]
        public ICollection<AdditionalMember> AdditionalMembers { get; set; }
    }

}
