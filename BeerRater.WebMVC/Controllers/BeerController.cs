using BeerRater.Models;
using System.Security.Principal;
using BeerRater.Data;
using BeerRater.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BeerRater.WebMVC.Controllers
{
    [Authorize]
    public class BeerController : Controller

    {
        private readonly ApplicationDbContext _ctx;
        private readonly IBeerService _beerService;

        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }
        public IActionResult Index()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new BeerService();

            var model = _beerService.GetBeers();

            return View(model);
        }
        
        public ActionResult Create()
        {
            var typeList = _beerService.BeerTypeList();
            var typeList2 = _beerService.BreweryList();
            ViewBag.BeerTypeId = new SelectList(typeList, "TypeId", "Name");
            ViewBag.BreweryId = new SelectList(typeList2, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerCreate model)
        {
            //if (!SetUserIdInService())

                if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Beer could not be created.");
  
                 return View(model);

            }

            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new BeerService(userId);
            if (!_beerService.SetUserIdInService(GetUserId())) return Unauthorized();
            _beerService.CreateBeer(model);
            TempData["SaveResult"] = "Your beer was created.";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = _beerService.GetBeerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var detail = _beerService.GetBeerById(id);
            var model =
                new BeerEdit
                {
                    Id = detail.Id,
                    BeerName = detail.BeerName,
                    Description = detail.Description
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BeerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            
            if (_beerService.EditBeer(model))
            {
                TempData["SaveResult"] = "Your beer was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your beer could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            
            var model = _beerService.GetBeerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBeer(int id)
        {
            _beerService.DeleteBeer(id);
            TempData["SaveResult"] = "Your Beer was deleted";
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
