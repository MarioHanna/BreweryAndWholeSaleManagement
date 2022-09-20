using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request
{
    public class BeerRequestDto
    {
        public int BeerId { get; set; }
        public int WholesalerId { get; set; }
        public int Quantity { get; set; }
    }
}
