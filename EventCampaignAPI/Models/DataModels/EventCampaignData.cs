using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventCampaignAPI.Models.DataModels
{
    [Table("event_campaign")]
    public class EventCampaignData
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lang_code { get; set; }
        [Required]
        public int shopping_center_id { get; set; }
        [Required]
        public DateTime start_date { get; set; }
        [Required]
        public DateTime end_date { get; set; }
    }
}
