using Announcements.Core;
using Announcements.Core.Announcements;
using Announcements.Core.DTOs.AnnouncementDTOs.Announcements;
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

        public AnnouncementController(IMapper mapper, IAnnouncementService service)
        {
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// Gets page number and page size and return elements in that range
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns> list of specified range elements  </returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Get Announcements By pager number and page size", Description = "Get Announcements By pager number and page size")]
        public async Task<IActionResult> GetAll(int pageNumber = 1,int pageSize = 10)
        {
            var annoumcements = await _service.GetAllAsync();
            var pagination =  annoumcements
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize);
                                 
            var annDtos = _mapper.Map<List<AnnouncementDto>>(pagination.ToList());

            return Ok(annDtos);

        }
        /// <summary>
        /// Gets slug of the Announcement and returns that spesific item
        /// </summary>
        /// <param name="slug"></param>
        /// <returns>spesific item which is called by slug endpoint</returns>
        [HttpGet("{slug}")]
        [SwaggerOperation(Summary = "Get Announcement By Slug", Description = "Get Announcement By Slug")]
        public Task<ActionResult<Announcement>> GetAnnouncementBySlug(string slug)
        {
            var announcements = _service.Where(a => a.Slug == slug);

            if (!announcements.Any())
            {
                return Task.FromResult<ActionResult<Announcement>>(NotFound());
            }
            return Task.FromResult<ActionResult<Announcement>>(Ok(announcements.FirstOrDefault()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnnouncementDto announcementDto)
        {
            var announcement = await _service.AddAsync(_mapper.Map<Announcement>(announcementDto));
            return Ok(announcement);
        }

        [HttpPut]

        public async Task<IActionResult> Update(AnnouncementDto announcementDto)
        {
            await _service.UpdateAsync(_mapper.Map<Announcement>(announcementDto));
            return Ok();
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var announcement = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(announcement);
            return Ok();
        }

    }
}
