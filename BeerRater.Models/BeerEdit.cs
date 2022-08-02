using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class BeerEdit
    {
        public int Id { get; set; }
        [Display(Name = "Beer Name")]

        public string BeerName { get; set; }
        public string Description { get; set; }
    }
}
