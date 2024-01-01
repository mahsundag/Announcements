using Announcements.Core.Announcements;
using Announcements.Core.DTOs.AnnouncementDTOs.AnnouncementDetails;
using Announcements.Core.DTOs.AnnouncementDTOs.Announcements;
using Announcements.Service.Services.AnnouncementDetails;
using Announcements.Service.Services.Announcements;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Announcements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementDetailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementDetailService _service;
        private readonly IAnnouncementService _announcementService;
        private readonly ILogger<AnnouncementDetailController> _logger;
        public AnnouncementDetailController(IMapper mapper, IAnnouncementDetailService service, IAnnouncementService announcementService, ILogger<AnnouncementDetailController> logger)
        {
            _mapper = mapper;
            _service = service;
            _announcementService = announcementService;
            _logger = logger;
        }
        /// <summary>
        /// Get Announcement by AnnouncementId 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>AnnouncementDetail</returns>
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Get Announcement Detail By Announcement Id", Description = "Get Announcement Detail  By Announcement Id")]
        public Task<ActionResult<AnnouncementDetail>> GetAnnouncementDetailById(int id)
        {
            var announcementDetails = _service.Where(a => a.AnnouncementId == id);

            if (!announcementDetails.Any())
            {
                _logger.LogInformation("No Data.");
                return Task.FromResult<ActionResult<AnnouncementDetail>>(NotFound());
            }
            return Task.FromResult<ActionResult<AnnouncementDetail>>(Ok(announcementDetails.First()));
        }
        /// <summary>
        /// Get Announcement by slug then get AnnouncementDetail  with that Announcement id 
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>AnnouncementDetailDto</returns>
        [HttpGet("{slug}")]
        [SwaggerOperation(Summary = "Get Announcement Detail By slug", Description = "Get Announcement Detail  By Announcement Id")]
        public Task<ActionResult<AnnouncementDetailDto>> GetAnnouncementDetailSlug(string slug)
        {
            var announcements = _announcementService.Where(x=>x.Slug == slug);

            if (!announcements.Any())
            {
                return Task.FromResult<ActionResult<AnnouncementDetailDto>>(NotFound());
            }

            var firstAnnouncementId = announcements.First().Id;
            var announcementDetails = _service.Where(a => a.AnnouncementId == firstAnnouncementId);

            if (!announcementDetails.Any())
            {
                return Task.FromResult<ActionResult<AnnouncementDetailDto>>(NotFound());
            }

            return Task.FromResult<ActionResult<AnnouncementDetailDto>>(Ok(_mapper.Map<AnnouncementDetailDto>(announcementDetails.First())));
        }
        /// <summary>
        /// Create an Detail with model
        /// </summary>
        /// <param name="announcementDetailDto"></param>
        /// <returns></returns>
        
        [HttpPost]
        [SwaggerOperation(Summary = "Create Announcement Detail", Description = "Create an Announcement Detail By Model")]
        public async Task<IActionResult> Create(AnnouncementDetailDto announcementDetailDto)
        {
            var announcement = await _service.AddAsync(_mapper.Map<AnnouncementDetail>(announcementDetailDto));
            return Ok(announcement);
        }
        /// <summary>
        /// Updates a spesific announcement detail
        /// </summary>
        /// <param name="announcementDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Update Announcement Detail", Description = "Update an Announcement Detail By Model")]
        public async Task<IActionResult> Update(AnnouncementDetailDto announcementDto)
        {
            await _service.UpdateAsync(_mapper.Map<AnnouncementDetail>(announcementDto));
            return Ok();
        }
        /// <summary>
        /// Deletes A Announcement Detail with Announcement Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete Announcement Detail", Description = "Delete an Announcement Detail By Id")]
        public async Task<IActionResult> Delete(int id)
        {
            var announcementDetails = _service.Where(x=>x.AnnouncementId==id);
            if (announcementDetails.Any())
            {
                await _service.RemoveAsync(announcementDetails.First());
            }
            return Ok();
        }
    }
}
