using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock
{
    public class CreateWholesalerStockDto
    {
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
