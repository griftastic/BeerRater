using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class BreweryBeerListItem
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public int BeerTypeId { get; set; }
        public string BeerTypeName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Average Score")]
        public double Score { get; set; }


    }
}
