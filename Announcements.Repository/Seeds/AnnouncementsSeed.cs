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
    public class AnnouncementsSeed : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasData(
                new Announcement { 
                    Id = 1,
                    Title = "İç ilan",
                    ShortText = "A ekibine tester aranıyor.",
                    Slug= "ic-ilan",
                    CreatedDate = DateTime.Now
                   

                },
                new Announcement
                {
                    Id = 2,
                    Title = "İç ilan",
                    ShortText = "B ekibine tester aranıyor.",
                    Slug = "ic-ilan",
                    CreatedDate = DateTime.Now


                },
                new Announcement
                {
                    Id = 3,
                    Title = "Eğitim",
                    ShortText = "11 Ocakta Zamanımı nasıl yönetirim semineri düzenlemnecektir. ",
                    Slug = "egitim",
                    CreatedDate = DateTime.Now


                },
                new Announcement
                {
                    Id =4,
                    Title = "Bilgilendirme",
                    ShortText = "A bölgesi direktörümüz Sayın Ahmet Mehmet Emekliliğe ayrılıyor ",
                    Slug = "bilgilendirme",
                    CreatedDate = DateTime.Now


                },
                new Announcement
                {
                    Id = 5,
                    Title = "Yazılım Eğitimi",
                    ShortText = "1 şubat - 1 Mayıs arası online olarak her salı phyton eğitimleri yapılacatır.",
                    Slug = "yazilim-egitimi",
                    CreatedDate = DateTime.Now


                }
                );
        }
    }
}
