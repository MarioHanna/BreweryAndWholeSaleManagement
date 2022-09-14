using BreweryAndWholeSaleManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Domain
{
    public class WholesalerStock : BaseDomainEntity
    {
        public Wholesaler Wholesaler { get; set; }
        public int WholesalerId { get; set; }
        public Beer Beer { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }

    }
}
