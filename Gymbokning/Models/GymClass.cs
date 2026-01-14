using System.ComponentModel.DataAnnotations;

namespace Gymbokning.Models
{
    public class GymClass
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public DateTime StartTime { get; set; }

        [Display(Name = "Duration (HH:mm)")]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        public DateTime EndTime => StartTime + Duration;
        public string Description { get; set; }
        
        // Navigation Property
        public ICollection<ApplicationUser> AttendingMembers { get; set; }
            = new List<ApplicationUser>();
    }
}
