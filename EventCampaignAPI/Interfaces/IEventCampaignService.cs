using EventCampaignAPI.Models.ClientModels;

namespace EventCampaignAPI.Interfaces
{
    public interface IEventCampaignService
    {
        Task<EventCampaign> GetEventCampaign(int id);
        Task<EventCampaign> SaveEventCampaign(EventCampaign model);
        Task<bool> DeleteEventCampaign(int id);
        Task<List<EventCampaign>> GetEventCampaignList(int? shoppingCenterId);
    }
}
