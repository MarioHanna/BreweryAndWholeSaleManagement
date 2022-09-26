using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using Moq;
using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockLeaveTypeRepo = MockBeerRepository.GetBeerRepository();

            mockUow.Setup(r => r.BeerRepository).Returns(mockLeaveTypeRepo.Object);

            return mockUow;
        }
    }
}
