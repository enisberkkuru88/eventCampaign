namespace EventCampaignAPI.Models.ClientModels
{
    public class EventCampaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LangCode { get; set; }
        public int ShoppingCenterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
