using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Core.DTOs.AnnouncementDTOs.AnnouncementDetails
{
    public class AnnouncementDetailDto:BaseDto
    {

        public int AnnouncementId { get; set; }
        public string Detail { get; set; }
    }
}
