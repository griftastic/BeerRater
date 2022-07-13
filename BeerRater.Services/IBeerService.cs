using BeerRater.Data;
using BeerRater.Models;

namespace BeerRater.Services
{
    public interface IBeerService
    {
        bool CreateBeer(BeerCreate model);
        IEnumerable<BeerListItem> GetBeers();
        BeerDetail GetBeerById(int id);
        bool EditBeer(BeerEdit model);
        
        bool SetUserIdInService(Guid userId);
        List<BeerType> BeerTypeList();
    }
}