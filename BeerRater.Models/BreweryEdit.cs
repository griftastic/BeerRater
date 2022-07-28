using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class BreweryEdit
    {
        public int Id { get; set; } 
        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Location { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }

    }
}
