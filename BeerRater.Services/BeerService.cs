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
    public class BeerService : IBeerService
    {
        private Guid _userId;
        //private readonly Guid _userId;
        private readonly ApplicationDbContext _ctx;
        //public BeerService(Guid userId, ApplicationDbContext ctx)
        //{
        //    _userId = userId;
        //    _ctx = ctx;
        //}


        public BeerService(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public bool CreateBeer(BeerCreate model)
        {
            var entity =
                new Beer()
                {
                    BeerName = model.BeerName,
                    Brewery = model.Brewery,
                    BeerTypeId = model.BeerTypeId,
                    Description = model.Description
                };
            _ctx.Beers.Add(entity);
            return _ctx.SaveChanges() == 1;
        }
        public IEnumerable<BeerListItem> GetBeers()
        {
            var query =
                _ctx
                    .Beers
                    .Select(
                        e =>
                            new BeerListItem
                            {
                                Id = e.Id,
                                Brewery = e.Brewery,
                                BeerName = e.BeerName,
                                BeerTypeName = e.BeerType.Name
                                //Description = e.Description

                            }
                            );
            return query.ToArray();
        }

        public BeerDetail GetBeerById(int id)
        {
                var entity =
                    _ctx
                        .Beers
                        .Include(e => e.BeerType)
                        .Single(e => e.Id == id);

            return
                new BeerDetail
                {
                    Id = entity.Id,
                    BeerName = entity.BeerName,
                    Brewery = entity.Brewery,
                    BeerTypeId = entity.BeerTypeId,
                    BeerTypeName = entity.BeerType.Name,
                    Description = entity.Description,
                    Score = entity.Score
                    };
                }

        public bool EditBeer(BeerEdit model)
        {
            var entity =
                _ctx.Beers.Single(e => e.Id ==model.Id);

            entity.BeerName = model.BeerName;
            entity.Description = model.Description;

            return _ctx.SaveChanges() == 1;
        }
        public bool SetUserIdInService(Guid userId)
        {
            if (userId == null)
                return false;

            _userId = userId;
            return true;
        }

        public List<BeerType> BeerTypeList()
        {
            var styles = _ctx.BeerTypes.ToList();
            return styles;
        }
        //public void SetUserId(Guid userId) => _userId = userId;

    }
}
