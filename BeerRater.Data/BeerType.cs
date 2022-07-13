using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Data
{
    public class BeerType
    {
        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }
    }
}
