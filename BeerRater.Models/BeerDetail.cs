using BeerRater.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Models
{
    public class BeerDetail
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public string Brewery { get; set; }
        public string BeerTypeName { get; set; }
        public int BeerTypeId { get; set; }
        public string Description { get; set; }
        public double Score { get; set; }
    }
}
