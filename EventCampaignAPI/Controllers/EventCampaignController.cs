using EventCampaignAPI.Interfaces;
using EventCampaignAPI.Models.ClientModels;
using Microsoft.AspNetCore.Mvc;

namespace EventCampaignAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventCampaignController : Controller
    {
        public IEventCampaignService _eventCampaignService;
        public EventCampaignController(IEventCampaignService eventCampaingService) {
            _eventCampaignService = eventCampaingService;
        }

        /// <summary>
        /// Get Specific Event Campaign
        /// </summary>
        /// <param name="id">id of event campiagn</param>
        /// <returns>Return event campaign model</returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_eventCampaignService.GetEventCampaign(id));
        }

        /// <summary>
        /// Save Event Campaign
        /// </summary>
        /// <param name="model">Event Campaign model</param>
        /// <returns>Returns saved event campaign model</returns>
        [HttpPost]
        [HttpPut]
        public IActionResult Save(EventCampaign model)
        {
            return Ok(_eventCampaignService.SaveEventCampaign(model));
        }

        /// <summary>
        /// Delete Event Campaign
        /// </summary>
        /// <param name="id">Event Campaign id</param>
        /// <returns>Returns true if event campaign deleted. else false</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_eventCampaignService.DeleteEventCampaign(id));
        }

        /// <summary>
        /// Event Campaign List
        /// </summary>
        /// <param name="shoppingCenterId">Shopping Center Id</param>
        /// <returns>Returns all event campaigns. if given param returns specific shopping center event campaign list</returns>
        [HttpGet("List")]
        public IActionResult List(int? shoppingCenterId)
        {
            return Ok(_eventCampaignService.GetEventCampaignList(shoppingCenterId));
        }
    }
}
