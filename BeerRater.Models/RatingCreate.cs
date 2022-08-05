using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class RatingCreate
    {
        public string UserId { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage ="There are too many characters in this field")]
        public string Review { get; set; }
        [Display(Name = "Beer Name")]

        public int BeerId { get; set; }
        [Required]
        [Range(1,5, ErrorMessage ="Please choose a number beteween 1 and 5")]
        [Display(Name = "Score (Select a number between 1 and 5)")]

        public double Score { get; set; }
    }
}
