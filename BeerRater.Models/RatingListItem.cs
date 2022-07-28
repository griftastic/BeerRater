using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class RatingListItem
    {
        public int Id { get; set; }
        [Display(Name = "Beer")]
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        [Display(Name = "Rating")]
        public double Score { get; set; }
    }
}
