using BeerRater.Data;
using BeerRater.Models;

namespace BeerRater.Services
{
    public interface IRatingService
    {
        bool SetUserIdInService(Guid userId);

        IEnumerable<RatingListItem> GetRatings();
        bool CreateRating(RatingCreate model);
        bool EditRating(RatingEdit model);
        RatingDetail GetRatingById(int id);
        bool DeleteRating(int id);
        List<Beer> BeerList();
    }
}
