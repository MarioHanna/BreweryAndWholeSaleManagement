using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Handlers.Commands;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Commands;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Application.Profiles;
using BreweryAndWholeSaleManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BreweryAndWholeSaleManagement.Application.UnitTests.Beers.Commands
{
    public class CreateBeerCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateBeerDto _BeerDto;
        private readonly CreateBeerCommandHandler _handler;

        public CreateBeerCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();
            
            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateBeerCommandHandler(_mockUow.Object, _mapper);

            _BeerDto = new CreateBeerDto
            {
                AlcoholContent = 15,
                BreweryId = 1,
                Price = 2000,
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task Valid_Beer_Added()
        {
            var result = await _handler.Handle(new CreateBeerCommand() { CreateBeerDto = _BeerDto }, CancellationToken.None);

            var Beers = await _mockUow.Object.BeerRepository.GetAll();

            result.ShouldBeOfType<int>();

            Beers.Count.ShouldBe(3);
        }

    }
}
