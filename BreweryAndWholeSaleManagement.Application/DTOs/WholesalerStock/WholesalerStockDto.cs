using BreweryAndWholeSaleManagement.Application.DTOs.Beer;
using BreweryAndWholeSaleManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock
{
    public class WholesalerStockDto : BaseDto
    {
        public WholesalerDto Wholesaler { get; set; }
        public int WholesalerId { get; set; }
        public BeerDto Beer { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
