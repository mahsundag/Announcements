using Announcements.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Repository.Configurations
{
    public class AnnouncumentDetailConfigurations : IEntityTypeConfiguration<AnnouncementDetail>
    {
        public void Configure(EntityTypeBuilder<AnnouncementDetail> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();
            builder.HasOne
              (x => x.Announcement)
              .WithOne(y => y.AnnouncementDetail)
              .HasForeignKey<AnnouncementDetail>(y => y.AnnouncementId);
        }
    }
}
