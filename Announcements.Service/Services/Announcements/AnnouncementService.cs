using Announcements.Core;
using Announcements.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Service.Services.Announcements
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IRepository<Announcement> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public AnnouncementService(IRepository<Announcement> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
     

        public async Task<Announcement> AddAsync(Announcement entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<Announcement>> AddRangeAsync(IEnumerable<Announcement> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<Announcement, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<Announcement> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Announcement entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(Announcement entity)
        {

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<Announcement> Where(Expression<Func<Announcement, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
