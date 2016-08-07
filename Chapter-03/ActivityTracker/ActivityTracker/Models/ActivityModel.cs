using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Models
{
    public class ActivityModel
    {
        [Key]
        public int ActivityId { get; set; }
        [MaxLength(10)]
        public string Activity { get; set; }
        [MaxLength(25)]
        public string Action { get; set; }
        [MaxLength(65)]
        public string Description { get; set; }
        public string Data { get; set; }
    }
}
