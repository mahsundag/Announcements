using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Core.DTOs.AnnouncementDTOs.Announcements
{
    public class AnnouncementResponseDto
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string ShortText { get; set; }

        public DateTime Date { get; set; }

        public string Detail { get; set; }
    }
}
