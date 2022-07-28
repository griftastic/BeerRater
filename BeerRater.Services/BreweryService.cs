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
    public class BreweryService : IBreweryService
    {
        private Guid _userId;
        //private readonly Guid _userId;
        private readonly ApplicationDbContext _ctx;
        //public BeerService(Guid userId, ApplicationDbContext ctx)
        //{
        //    _userId = userId;
        //    _ctx = ctx;
        //}


        public BreweryService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public bool CreateBrewery(BreweryCreate model)
        {
            var entity =
                new Brewery()
                {
                    Name = model.Name,
                    Location = model.Location,
                    Description = model.Description
                };
            _ctx.Breweries.Add(entity);
            return _ctx.SaveChanges() == 1;
        }
        public IEnumerable<BreweryListItem> GetBreweries()
        {
            var query =
                _ctx
                    .Breweries
                    .Select(
                        e =>
                            new BreweryListItem
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Location = e.Location
                            }
                            );
            return query.ToArray();
        }

        public IEnumerable<BreweryBeerListItem> GetBeersByBrewery(int id)
        {
            var beersList =
                from Beers in _ctx.Breweries.DistinctBy(e => e.Id == id)/*.Include("Beer")*/
                //where Beers.Id == id
                select new BreweryBeerListItem
                {
                    BeerId = Beers.Id,
                    BeerName = Beers.Name,
                };

            //var entity =
            //    _ctx
            //    .Breweries
            //    .Where(e => e.Id == id)
            //    .Include(e => e.Beers)
            //    .Where()
            //    .Select(
            //       Beers => 
            //            new BreweryBeerListItem
            //                    {
            //                        Id = Beers.Id,
            //                        BeerName = BeersName,
            //                        BeerTypeName = Beers.BeerType,
            //                        Score = Beers.Score
            //                    });

            return beersList.AsEnumerable();

        }

        public BreweryDetail GetBreweryById(int id)
        {
            var entity =
                _ctx
                    .Breweries
                    .Single(e => e.Id == id);

            return
                new BreweryDetail
                {
                    Name = entity.Name,
                    Location = entity.Location,
                    Description = entity.Description
                };
        }

        public bool EditBrewery(BreweryEdit model)
        {
            var entity =
                _ctx
                    .Breweries
                    .Single(e => e.Id == model.Id);

            entity.Name = model.Name;
            entity.Location = model.Location;   
            entity.Description = model.Description;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteBrewery(int breweryId)
        {
            var entity =
               _ctx
                    .Breweries
                    .Single(e => e.Id == breweryId);

            _ctx.Breweries.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
        public bool SetUserIdInService(Guid userId)
        {
            if (userId == null)
                return false;

            _userId = userId;
            return true;
        }


    }
}
