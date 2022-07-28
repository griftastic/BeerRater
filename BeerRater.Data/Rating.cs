using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Data
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(Beer))]
        public int BeerId { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage="There are too many characters in this field.")]
        public string Review { get; set; }
        [Required]
        [Range(1,5, ErrorMessage ="Please choose a number between 1 and 5")]
        
        public double Score { get; set; }
        public virtual Beer Beers { get; set; }
    }
}
