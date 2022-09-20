using BreweryAndWholeSaleManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.WholesalerStock
{
    public class UpdateWholesalerStockDto : BaseDto
    {
        public int Quantity { get; set; }
    }
}
