using Announcements.Core.Announcements;
using Announcements.Core.DTOs.AnnouncementDTOs.AnnouncementDetails;
using Announcements.Core.DTOs.AnnouncementDTOs.Announcements;
using AutoMapper;

namespace Announcements.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();

            CreateMap<AnnouncementDetail, AnnouncementDetailDto>().ReverseMap();
        }

    }
}
