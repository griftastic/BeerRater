using BeerRater.Models;
using BeerRater.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeerRater.WebMVC.Controllers
{
    [Authorize]
    public class BreweryController : Controller
    {
        public readonly IBreweryService _breweryService;

        public BreweryController(IBreweryService breweryService)
        {
            _breweryService = breweryService;
        }

        // GET: BreweryController
        public ActionResult Index()
        {
            var model = _breweryService.GetBreweries();
            return View(model);
        }

        // GET: BreweryController/Details/5
        public ActionResult Details(int id)
        {
            var model = _breweryService.GetBreweryById(id);


            return View(model);
        }

        // GET: BreweryController/Details2
        public ActionResult Details2(int id)
        {
            var model = _breweryService.GetBeersByBrewery(id);
            return View(model);
        }

        // GET: BreweryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreweryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryCreate model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Brewery could not be created.");
          
                return View(model);
            }
            if (!_breweryService.SetUserIdInService(GetUserId())) return Unauthorized();
            _breweryService.CreateBrewery(model);
            TempData["SaveResult"] = "Your brewery was created.";
            return RedirectToAction("Index");
            
        }

        // GET: BreweryController/Edit/5
        public ActionResult Edit(int id)
        {
            var detail = _breweryService.GetBreweryById(id);
            var model =
                new BreweryEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Location = detail.Location,
                    Description = detail.Description

                };
            return View(model);
        }

        // POST: BreweryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BreweryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if (_breweryService.EditBrewery(model)) ;
            {
                TempData["SaveResult"] = "Your brewery was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your brewery could not be updated.");
            return View(model);
        }

        // GET: BreweryController/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = _breweryService.GetBreweryById(id);
            return View(model);
        }

        // POST: BreweryController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBrewery(int id)
        {
            _breweryService.DeleteBrewery(id);
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
