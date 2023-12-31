using Announcements.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Repository
{
    public class AnnouncumentsDbContext:DbContext
    {
        public AnnouncumentsDbContext(DbContextOptions<AnnouncumentsDbContext> options):base(options)
        {
            
        }

        public DbSet<Announcement> Announcements { get; set; }
    }
}
