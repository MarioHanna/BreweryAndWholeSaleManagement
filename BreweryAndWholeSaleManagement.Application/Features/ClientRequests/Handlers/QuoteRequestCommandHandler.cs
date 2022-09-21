using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs.Request;
using BreweryAndWholeSaleManagement.Application.Features.ClientRequests.Requests;
using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Features.ClientRequests.Handlers
{
    public class QuoteRequestCommandHandler : IRequestHandler<QuoteRequestCommand, QuoteRequestResultDto>
    {
        private readonly IWholesalerStockRepository _wholesalerStockRepository;
        private readonly IMapper _mapper;

        public QuoteRequestCommandHandler(IWholesalerStockRepository wholesalerStockRepository, IMapper mapper)
        {
            _wholesalerStockRepository = wholesalerStockRepository;
            _mapper = mapper;
        }

        public async Task<QuoteRequestResultDto> Handle(QuoteRequestCommand request, CancellationToken cancellationToken)
        {
            int BeerCount = 0;
            double TotalPrice = 0;
            QuoteRequestResultDto quoteRequestResultDto = new QuoteRequestResultDto();

            foreach (BeerRequestDto beerRequest in request.clientRequestDto.BeerRequestList)
            {
                BeerRequestResultDto beerRequestResultDto = new BeerRequestResultDto();
                WholesalerStock wholesalerStock = await _wholesalerStockRepository.GetWholesalerStockDetails(beerRequest.BeerId, beerRequest.WholesalerId);

                beerRequestResultDto.BeerName = wholesalerStock.Beer.Name;
                beerRequestResultDto.WholesalerName = wholesalerStock.Wholesaler.Name;
                beerRequestResultDto.Quantity = beerRequest.Quantity;
                beerRequestResultDto.TotalPrice = beerRequest.Quantity * wholesalerStock.Beer.Price;

                if (beerRequest.Quantity <= wholesalerStock.Quantity)
                {
                    BeerCount += beerRequest.Quantity;
                    TotalPrice += wholesalerStock.Beer.Price;
                    beerRequestResultDto.Status = "Accepted";
                }
                else
                {
                    beerRequestResultDto.Status = "Rejected";
                }

                quoteRequestResultDto.BeerRequestsResult.Add(beerRequestResultDto);
            }

            quoteRequestResultDto.TotalBeerCount = BeerCount;
            if (BeerCount > 10)
            {
                quoteRequestResultDto.TotalDiscountedPrice = TotalPrice * 90 /100;
            }

            if (BeerCount > 20)
            {
                quoteRequestResultDto.TotalDiscountedPrice = TotalPrice * 80 / 100;
            }

            return quoteRequestResultDto;
        }
    }
}
