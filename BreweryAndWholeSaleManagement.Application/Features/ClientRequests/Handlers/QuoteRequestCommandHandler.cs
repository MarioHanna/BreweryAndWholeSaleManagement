using AutoMapper;
using BreweryAndWholeSaleManagement.Application.DTOs.Request;
using BreweryAndWholeSaleManagement.Application.DTOs.Request.Validators;
using BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock;
using BreweryAndWholeSaleManagement.Application.Exceptions;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuoteRequestCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuoteRequestResultDto> Handle(QuoteRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new ClientRequestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.clientRequestDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            int BeerCount = 0;
            double TotalPrice = 0;
            QuoteRequestResultDto quoteRequestResultDto = new QuoteRequestResultDto();
            quoteRequestResultDto.BeerRequestsResult = new List<BeerRequestResultDto>();

            foreach (BeerRequestDto beerRequest in request.clientRequestDto.BeerRequestList)
            {
                var beerRequestvalidator = new BeerRequestDtoValidator(_unitOfWork.wholesalerRepository, _unitOfWork.BeerRepository);
                var beerRequestvalidatorResult = await beerRequestvalidator.ValidateAsync(beerRequest);

                if (beerRequestvalidatorResult.IsValid == false)
                    throw new ValidationException(beerRequestvalidatorResult);

                BeerRequestResultDto beerRequestResultDto = new BeerRequestResultDto();
                WholesalerStock wholesalerStock = await _unitOfWork.wholesalerStockRepository.GetWholesalerStockDetails(beerRequest.BeerId, beerRequest.WholesalerId);
                WholesalerStockDto wholesalerStockDto = _mapper.Map<WholesalerStockDto>(wholesalerStock);


                beerRequestResultDto.BeerName = wholesalerStock.Beer.Name;
                beerRequestResultDto.WholesalerName = wholesalerStock.Wholesaler.Name;
                beerRequestResultDto.Quantity = beerRequest.Quantity;
                beerRequestResultDto.TotalPrice = beerRequest.Quantity * wholesalerStock.Beer.Price;

                if (beerRequest.Quantity <= wholesalerStock.Quantity)
                {
                    BeerCount += beerRequest.Quantity;
                    TotalPrice += beerRequestResultDto.TotalPrice;
                    beerRequestResultDto.Status = "Accepted";
                }
                else
                {
                    beerRequestResultDto.Status = "Rejected";
                }

                quoteRequestResultDto.BeerRequestsResult.Add(beerRequestResultDto);
            }

            quoteRequestResultDto.TotalBeerCount = BeerCount;
            quoteRequestResultDto.TotalBeersPrice = TotalPrice;

            if (BeerCount > 10)
            {
                quoteRequestResultDto.Discount = "10%";
                quoteRequestResultDto.TotalDiscountedPrice = TotalPrice * 90 /100;
            }

            if (BeerCount > 20)
            {
                quoteRequestResultDto.Discount = "20%";
                quoteRequestResultDto.TotalDiscountedPrice = TotalPrice * 80 / 100;
            }

            return quoteRequestResultDto;
        }
    }
}
