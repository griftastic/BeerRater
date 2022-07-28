using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Data
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="There are too many characters in this field.")]
        public string BeerName { get; set; }
        
        [ForeignKey(nameof(Brewery))]
        public int BreweryId { get; set; }
        
        public virtual Brewery Breweries { get; set; }
        [ForeignKey(nameof(BeerType))]
        public int BeerTypeId { get; set; }
        public virtual BeerType BeerType { get; set; }
        //public string BeerType { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage ="There are too many characters in this field.")]
        public string Description { get; set; }
        public double Score
        {
            get
            {
                return Ratings.Count > 0 ? Ratings.Select(r => r.Score).Sum() / Ratings.Count : 0;
            }
        }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

    }
}
