using BeerRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Services
{
    public interface IBreweryService
    {
        bool SetUserIdInService(Guid userId);

        IEnumerable<BreweryListItem> GetBreweries();
        bool CreateBrewery(BreweryCreate model);
        bool EditBrewery(BreweryEdit model);
        BreweryDetail GetBreweryById(int id);
        bool DeleteBrewery(int id);
        IEnumerable<BreweryBeerListItem> GetBeersByBrewery(int id);

    }
}
