using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class BeerCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Beer Name")]

        public string BeerName { get; set; }
        [Required]
        [Display(Name = "Brewery")]

        public int BreweryId { get; set; }
        [Required]
        [Display(Name = "Type")]

        public int BeerTypeId { get; set; }
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }
    }
}
