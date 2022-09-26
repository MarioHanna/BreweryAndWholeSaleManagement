using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Handlers.Queries;
using BreweryAndWholeSaleManagement.Application.Features.Beers.Requests.Queries;
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

namespace BreweryAndWholeSaleManagement.Application.UnitTests.Queries
{
    public class GetBeerListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;

        public GetBeerListRequestHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c => 
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetBeerListTest()
        {
            var handler = new GetBeerListRequestHandler(_mockUow.Object, _mapper);

            var result = await handler.Handle(new GetBeerListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<BeerDto>>();

            result.Count.ShouldBe(2);
        }
    }
}
