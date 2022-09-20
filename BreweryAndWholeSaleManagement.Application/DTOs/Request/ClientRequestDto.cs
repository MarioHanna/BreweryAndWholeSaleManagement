using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Request
{
    public class ClientRequestDto
    {
        public List<BeerRequestDto> BeerRequestList { get; set; }
    }
}
