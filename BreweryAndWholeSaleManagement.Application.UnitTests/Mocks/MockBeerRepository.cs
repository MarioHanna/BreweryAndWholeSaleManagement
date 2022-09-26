using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.UnitTests.Mocks
{
    public static class MockBeerRepository
    {
        public static Mock<IBeerRepository> GetBeerRepository()
        {
            var Beers = new List<Beer>
            {
                new Beer
                {
                    Id = 1,
                    AlcoholContent = 7,
                    Name = "Test 1",
                    BreweryId = 1,
                    Price = 2500
                },
                new Beer
                {
                    Id = 2,
                    AlcoholContent = 9,
                    Name = "Test 2",
                    BreweryId = 2,
                    Price = 5500
                }
            };

            var mockRepo = new Mock<IBeerRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(Beers);

            mockRepo.Setup(r => r.Add(It.IsAny<Beer>())).ReturnsAsync((Beer Beer) => 
            {
                Beers.Add(Beer);
                return Beer;
            });

            return mockRepo;

        }
    }
}
