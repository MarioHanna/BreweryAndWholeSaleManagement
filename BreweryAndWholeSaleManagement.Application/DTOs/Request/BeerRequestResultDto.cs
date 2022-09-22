using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request
{
    public class BeerRequestResultDto
    {
        public string BeerName { get; set; }
        public string WholesalerName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
