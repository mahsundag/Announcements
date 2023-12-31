using Announcements.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Repository.Seeds
{
    internal class AnnouncementDetailsSeed : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasData(new AnnouncementDetail
            {
                Id = 1,
                AnnouncementId = 4,
                Detail = "A bölgesi direktörümüz Sayın Ahmet Mehmet Emekliliğe ayrılıyor ." +
                "Yerine yardımcısı olan Ayşe Yılmaz atanmıştır.Kendisine görevinde başarılar diliyoruz" +
                "Sayın Ahmet Mehmete Mutlu bir emeklilik diliyoruz."
            }, new AnnouncementDetail
            {
                Id = 2,
                AnnouncementId = 5,
                Detail = "1 şubat - 1 Mayıs arası online olarak her salı phyton eğitimleri yapılacatır." +
                "Eğitim saat 09:00 ile 12:00 arasında olacaktır. Eğitime katılacakların Eğitim-Gelişim departmanına " +
                "isimlerini verip dahil olabilir veya test.correndon.egtim/pyhton adresinden kayıt olabilirler."
            }
            );

        }
    }
}
