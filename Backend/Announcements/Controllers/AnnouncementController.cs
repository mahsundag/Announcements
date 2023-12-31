﻿using Announcements.Core;
using Announcements.Core.Announcements;
using Announcements.Core.DTOs.AnnouncementDTOs.Announcements;
using Announcements.Service.Services.AnnouncementDetails;
using Announcements.Service.Services.Announcements;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Announcements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementService _service;
        private readonly IAnnouncementDetailService _detailService;
        private readonly ILogger<AnnouncementController> _logger;
        public AnnouncementController(IMapper mapper, IAnnouncementService service, IAnnouncementDetailService detailService, ILogger<AnnouncementController> logger)
        {
            _mapper = mapper;
            _service = service;
            _logger = logger;
            _detailService = detailService;
        }
        /// <summary>
        /// Gets page number and page size and return elements in that range
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns> list of specified range elements  </returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Get Announcements By pager number and page size", Description = "Get Announcements By pager number and page size")]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            _logger.LogInformation("Getting All Data");
            var annoumcements = await _service.GetAllAsync();
            var announcementsCount = annoumcements.Count();
            var pagination = annoumcements
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize);
            var result = new AnnouncementListResponseDto
            {
                Count = announcementsCount,
                Data = _mapper.Map<List<AnnouncementDto>>(pagination)
            };
            var annDtos = _mapper.Map<AnnouncementListResponseDto>(result);

            return Ok(annDtos);

        }
        /// <summary>
        /// Gets slug of the Announcement and returns that spesific item
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>spesific item which is called by slug endpoint</returns>
        [HttpGet("{slug}")]
        [SwaggerOperation(Summary = "Get Announcement By Slug", Description = "Get Announcement By Slug")]
        public Task<ActionResult<AnnouncementResponseDto>> GetAnnouncementBySlug(string slug)
        {
            var announcements = _service.Where(a => a.Slug == slug);

            if (!announcements.Any())
            {
                _logger.LogInformation("No Data.");
                return Task.FromResult<ActionResult<AnnouncementResponseDto>>(NotFound());
            }
            var res = new AnnouncementResponseDto { };
            var announcement = announcements.FirstOrDefault();
            if (announcement is not null)
            {
                res.Slug = announcement.Slug;
                res.Title = announcement.Title;
                res.ShortText = announcement.ShortText;
                res.Date = announcement
                    .Date;
                var detail = _detailService.Where(x => x.AnnouncementId == announcement.Id);
                if (detail is not null)
                {
                   var det = detail.First();
                   res.Detail = det.Detail;
                }
            }
            return Task.FromResult<ActionResult<AnnouncementResponseDto>>(Ok(res));
        }
        /// <summary>
        /// Gets Announcement with Id , we added id:int for the multiple root match exception
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Announcement</returns>
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Get Announcement By Id", Description = "Get Announcement By Id")]
        public Task<ActionResult<Announcement>> GetAnnouncementById(int id)
        {
            var announcements = _service.Where(a => a.Id == id);

            if (!announcements.Any())
            {
                return Task.FromResult<ActionResult<Announcement>>(NotFound());
            }
            return Task.FromResult<ActionResult<Announcement>>(Ok(announcements.FirstOrDefault()));
        }
        /// <summary>
        /// Creating Announcement without detail part
        /// </summary>
        /// <param name="announcementDto"></param>
        /// <returns>announcement</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Create Announcement", Description = "Create an Announcement By Model")]
        public async Task<IActionResult> Create(AnnouncementDto announcementDto)
        {
            var announcement = await _service.AddAsync(_mapper.Map<Announcement>(announcementDto));
            return Ok(announcement);
        }
        /// <summary>
        /// Updates a spesific announcement 
        /// </summary>
        /// <param name="announcementDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Update Announcement", Description = "Update an Announcement By Model")]
        public async Task<IActionResult> Update(AnnouncementDto announcementDto)
        {
            await _service.UpdateAsync(_mapper.Map<Announcement>(announcementDto));
            return Ok();
        }
        /// <summary>
        /// Deletes A Announcement without Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete Announcement", Description = "Delete an Announcement By Id")]
        public async Task<IActionResult> Delete(int id)
        {
            var announcement = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(announcement);
            return Ok();
        }

    }
}
