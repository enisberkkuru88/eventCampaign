using EventCampaignAPI.Context;
using EventCampaignAPI.Interfaces;
using EventCampaignAPI.Models.ClientModels;
using EventCampaignAPI.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EventCampaignAPI.Services
{
    public class EventCampaignService : IEventCampaignService
    {
        private EventCampaignContext _context;
        public EventCampaignService(EventCampaignContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteEventCampaign(int id)
        {
            bool result = false;
            try
            {
                EventCampaignData? ecd = await _context.EventCampaignData.Where(l => l.id == id).FirstOrDefaultAsync();
                if (ecd != null)
                {
                    _context.EventCampaignData.Remove(ecd);
                    result = true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                //Add message or do smt.
            }

            return result;
        }

        public async Task<EventCampaign?> GetEventCampaign(int id)
        {
            EventCampaign? result = new EventCampaign();
            try
            {
                result = await _context.EventCampaignData.Where(l => l.id == id).Select(l => new EventCampaign
                {
                    EndDate = l.end_date,
                    Id = l.id,
                    LangCode = l.lang_code,
                    Name = l.name,
                    ShoppingCenterId = l.shopping_center_id,
                    StartDate = l.start_date,
                }).FirstOrDefaultAsync();
            }
            catch
            {
                //Add message or do smt.
            }
            return result;
        }

        public async Task<List<EventCampaign?>> GetEventCampaignList(int? shoppingCenterId)
        {
            List<EventCampaign?> result = new List<EventCampaign?>();
            try
            {
                IQueryable<EventCampaign?> tmpResult = _context.EventCampaignData.Select(l => new EventCampaign
                {
                    EndDate = l.end_date,
                    Id = l.id,
                    LangCode = l.lang_code,
                    Name = l.name,
                    ShoppingCenterId = l.shopping_center_id,
                    StartDate = l.start_date,
                }).AsQueryable();
                if (shoppingCenterId.HasValue)
                {
                    tmpResult = tmpResult.Where(l => l.ShoppingCenterId == shoppingCenterId);
                }
                result = await tmpResult.ToListAsync();
            }
            catch
            {
                //Add message or do smt.
            }
            return result;
        }

        public async Task<EventCampaign> SaveEventCampaign(EventCampaign model)
        {
            try
            {
                EventCampaignData ecd = new EventCampaignData();
                if (model.Id < 0)
                {
                    _context.Add(ecd);
                }

                ecd.end_date = model.EndDate;
                ecd.start_date = model.StartDate;
                ecd.lang_code = model.LangCode;
                ecd.shopping_center_id = model.ShoppingCenterId;

                await _context.SaveChangesAsync();

                model.Id = ecd.id;
            }
            catch
            {
                //Add message or do smt.
            }
            return model;
        }
    }
}
