using Announcements.Core;
using Announcements.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.Service.Services.AnnouncementDetails
{
    public class AnnouncementDetailService : IAnnouncementDetailService
    {
        private readonly IRepository<AnnouncementDetail> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public AnnouncementDetailService(IRepository<AnnouncementDetail> repository, IUnitOfWork unitOfWork)
        {

            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AnnouncementDetail> AddAsync(AnnouncementDetail entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<AnnouncementDetail>> AddRangeAsync(IEnumerable<AnnouncementDetail> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<AnnouncementDetail, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<AnnouncementDetail>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<AnnouncementDetail> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(AnnouncementDetail entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(AnnouncementDetail entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<AnnouncementDetail> Where(Expression<Func<AnnouncementDetail, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
