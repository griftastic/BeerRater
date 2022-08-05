using BeerRater.Data;
using BeerRater.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerRater.Services
{
    public class RatingService : IRatingService
    {
        private Guid _userId;
        private readonly ApplicationDbContext _ctx;
        public RatingService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public bool CreateRating(RatingCreate model)
        {
            
                var entity =
                    new Rating()
                    {
                        UserId = model.UserId,
                        BeerId = model.BeerId,
                        Review = model.Review,
                        Score = model.Score
                    };
            


            _ctx.Ratings.Add(entity);
            return _ctx.SaveChanges() == 1;
        }
        public IEnumerable<RatingListItem> GetRatings()
        {
            var query =
                _ctx
                    .Ratings
                    .Select(
                        e =>
                            new RatingListItem
                            {
                                Id = e.Id,
                                BeerId = e.Beers.Id,
                                BeerName = e.Beers.BeerName,
                                Score = e.Score
                            });
            return query.ToArray();
        }

        public RatingDetail GetRatingById(int id)
        {
            var entity =
                _ctx
                    .Ratings
                    .Include(e => e.Beers)
                    .Single(e => e.Id == id);

            return
                new RatingDetail
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    BeerName = entity.Beers.BeerName,
                    Review = entity.Review,
                    Score = entity.Score,
                };
        }


        public bool EditRating(RatingEdit model)
        {
            var entity =
                _ctx
                    .Ratings                 
                    .Single(e => e.Id == model.Id);

            entity.Review = model.Review;
            entity.Score = model.Score;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteRating(int ratingId)
        {
            var entity =
                _ctx
                    .Ratings
                    .Single(e => e.Id == ratingId);

            _ctx.Ratings.Remove(entity);

            return _ctx.SaveChanges() == 1; 
        }


        public bool SetUserIdInService(Guid userId)
        {
            if (userId == null)
                return false;

            _userId = userId;
            return true;

        }

        public List<Beer> BeerList()
        {
            var beernames = _ctx.Beers.ToList();
            return beernames;
        }


    }
}
