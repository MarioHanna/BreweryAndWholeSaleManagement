using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request
{
    public class QuoteRequestResultDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string BeerName { get; set; }
        public string WholesalerName { get; set; }
        public string Quantity { get; set; }
        public double Price { get; set; }
        public string Discount { get; set; }
        public double DiscountedPrice { get; set; }
    }
}
