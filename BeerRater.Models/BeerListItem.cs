using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class BeerListItem
    {
        public int Id { get; set; }
        public int BreweryId { get; set; }
        public string BeerName { get; set; }
        public string Brewery { get; set; }
        public int BeerTypeId { get; set; }
        [Display(Name="Type")]
        public string BeerTypeName { get; set; }
        public string Description { get; set; }

        [Display(Name="Average Score")]
        public double Score { get; set; }
    }
}
