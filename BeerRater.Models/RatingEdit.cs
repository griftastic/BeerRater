﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class RatingEdit
    {
        public int Id { get; set; }

        public string BeerName { get; set; }
        public string Review { get; set; }
        public double Score { get; set; }
    }
}
