using BreweryAndWholeSaleManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Domain
{
    public class Beer : BaseDomainEntity
    {
        public string Name { get; set; }
        public double AlcoholContent { get; set; }
        public double Price { get; set; }
        public Brewery Brewery { get; set; }
        public int BreweryId { get; set; }
    }
}
