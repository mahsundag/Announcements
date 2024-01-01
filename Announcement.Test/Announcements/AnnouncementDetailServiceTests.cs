using Announcements.Core;
using Announcements.Core.Announcements;
using Announcements.Service.Services.AnnouncementDetails;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Announcement.Test.Announcements
{
    public class AnnouncementDetailServiceTests
    {
        [Fact]
        public async Task AddAsync_ShouldAddAnnouncementDetail()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<AnnouncementDetail>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var service = new AnnouncementDetailService(mockRepo.Object, mockUnitOfWork.Object);
            var announcementDetail = new AnnouncementDetail { Id = 1, Detail = "xzcxzcx", AnnouncementId = 11 };

            // Act
            var result = await service.AddAsync(announcementDetail);

            // Assert
            mockRepo.Verify(x => x.AddAsync(announcementDetail), Times.Once);
            mockUnitOfWork.Verify(x => x.CommitAsync(), Times.Once);
            Assert.Equal(announcementDetail, result);
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllAnnouncementDetails()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<AnnouncementDetail>>();
            var expectedAnnouncementDetails = new List<AnnouncementDetail>
            {
                new AnnouncementDetail {  Id = 1, Detail = "xzcxzcx", AnnouncementId = 11},
                new AnnouncementDetail {  Id = 2, Detail = "xzcxzcx", AnnouncementId = 12 }
            }.AsQueryable();

            mockRepo.Setup(repo => repo.GetAll()).Returns(expectedAnnouncementDetails);

            // Entity Framework Core için gerekli olan IAsyncEnumerable desteğini ekleyin
            var mockIQueryable = expectedAnnouncementDetails.AsQueryable().BuildMock();
            mockRepo.Setup(m => m.GetAll()).Returns(mockIQueryable);

            var service = new AnnouncementDetailService(mockRepo.Object, new Mock<IUnitOfWork>().Object);

            // Act
            var result = await service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedAnnouncementDetails, result);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnAnnouncementDetail_WhenAnnouncementDetailExists()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<AnnouncementDetail>>();
            var announcementDetail = new AnnouncementDetail { Id = 1, Detail = "", AnnouncementId = 11 };
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(announcementDetail);
            var service = new AnnouncementDetailService(mockRepo.Object, new Mock<IUnitOfWork>().Object);

            // Act
            var result = await service.GetByIdAsync(1); 

            // Assert
            Assert.NotNull(result);
            Assert.Equal(announcementDetail, result);
        }


    }

}
