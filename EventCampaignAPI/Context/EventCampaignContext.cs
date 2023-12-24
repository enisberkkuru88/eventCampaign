using EventCampaignAPI.Models.DataModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace EventCampaignAPI.Context
{
    public class EventCampaignContext : DbContext
    {
        public EventCampaignContext(DbContextOptions<EventCampaignContext> options) : base(options) { }

        public DbSet<EventCampaignData> EventCampaignData { get; set; }
    }
}
