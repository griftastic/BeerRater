using BeerRater.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeerRater.Services;
using System.Security.Claims;
using BeerRater.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerRater.WebMVC.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public IActionResult Index()
        {
            //var model = new RatingListItem[0];
            var model = _ratingService.GetRatings();
            return View(model);
        }

        public ActionResult Create()
        {
            var beerList = _ratingService.BeerList();
            ViewBag.BeerId = new SelectList(beerList, "Id", "BeerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Rating could not be created.");
                return View(model);
            }

            if (!_ratingService.SetUserIdInService(GetUserId())) return Unauthorized();
            _ratingService.CreateRating(model);
            TempData["SaveResult"] = "Your rating was created.";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _ratingService.GetRatingById(id);

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var detail = _ratingService.GetRatingById(id);
            var model =
                new RatingEdit
                {
                    Review = detail.Review,
                    Score = detail.Score
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_ratingService.EditRating(model)) ;
            {
                TempData["SaveResult"] = "Your rating was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your rating could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _ratingService.GetRatingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRating(int id)
        {
            _ratingService.DeleteRating(id);
            TempData["SaveResult"] = "Your Rating was deleted";
            return RedirectToAction("Index");
        }
        private Guid GetUserId()
        {
            string userId = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userId == null) return default;
            return Guid.Parse(userId);
        }

    }
}
