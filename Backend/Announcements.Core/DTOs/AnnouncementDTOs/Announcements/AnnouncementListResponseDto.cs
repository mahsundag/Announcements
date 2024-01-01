using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Core.DTOs.AnnouncementDTOs.Announcements
{
    public class AnnouncementListResponseDto
    {
        public int Count { get; set; }

        public List<AnnouncementDto> Data { get; set; }
    }
}
