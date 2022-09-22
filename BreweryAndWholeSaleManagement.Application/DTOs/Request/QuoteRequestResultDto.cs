using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request
{
    public class QuoteRequestResultDto
    {
        public List<BeerRequestResultDto> BeerRequestsResult { get; set; }
        public int TotalBeerCount { get; set; }
        public string Discount { get; set; }
        public double TotalBeersPrice { get; set; }
        public double TotalDiscountedPrice { get; set; }
    }
}
