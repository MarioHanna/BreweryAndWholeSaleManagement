﻿using BreweryAndWholeSaleManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.DTOs
{
    public class BeerDto : BaseDto
    {
        public string Name { get; set; }
        public double AlcoholContent { get; set; }
        public double Price { get; set; }
        public BreweryDto Brewery { get; set; }
        public int BreweryId { get; set; }
    }
}
