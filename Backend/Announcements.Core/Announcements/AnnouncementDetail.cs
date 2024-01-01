using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Core.Announcements
{
    public sealed class AnnouncementDetail
    {
        public int Id { get; set; }
        public string Detail { get; set; }

        public int AnnouncementId { get; set; }

        public Announcement Announcement { get; set; }
    }
}
