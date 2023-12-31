using Announcements.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AnnouncementsDbContext _announcumentsDbContext;
        public UnitOfWork(AnnouncementsDbContext announcumentsDbContext)
        {
                _announcumentsDbContext = announcumentsDbContext;
        }
        public void Commit()
        {
            _announcumentsDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _announcumentsDbContext.SaveChangesAsync();
        }
    }
}
