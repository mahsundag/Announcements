using Announcements.Core;
using Announcements.Core.Announcements;
using Announcements.Core.DTOs.AnnouncementDTOs.Announcements;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Announcements.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Announcement> _service;

        public AnnouncementController(IMapper mapper, IService<Announcement> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All(int pageNumber = 1,int pageSize = 10)
        {
            var annoumcements = await _service.GetAllAsync();
            var pagination =  annoumcements
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize);
                                 
            var annDtos = _mapper.Map<List<AnnouncementDto>>(pagination.ToList());

            return Ok(annDtos);

        }
        [HttpGet("{slug}")]
        public async Task<ActionResult<Announcement>> GetAnnouncementBySlug(string slug)
        {
            var announcements = _service.Where(a => a.Slug == slug);

            if (!announcements.Any())
            {
                return NotFound();
            }
            return Ok(announcements.FirstOrDefault());
        }
    }
}
