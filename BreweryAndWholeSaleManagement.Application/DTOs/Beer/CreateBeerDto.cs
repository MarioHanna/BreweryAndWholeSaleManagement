using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs.Beer
{
    public class CreateBeerDto
    {
        public string Name { get; set; }
        public double AlcoholContent { get; set; }
        public double Price { get; set; }
        public int BreweryId { get; set; }
    }
}
