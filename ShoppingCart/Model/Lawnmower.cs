﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Model
{
    public class Lawnmower:Product
    {
        public string FuelEfficiency { get; set; }
        public bool IsVehicle { get; set; }

        public string Brand { get; set; }
    }
}
