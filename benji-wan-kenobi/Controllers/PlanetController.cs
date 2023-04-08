using benji_wan_kenobi.Data;
using benji_wan_kenobi.Models;
using Microsoft.AspNetCore.Mvc;

namespace benji_wan_kenobi.Controllers
{
    public class PlanetController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlanetController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Planet> objPlanetList = _db.Planets;
            return View(objPlanetList);
        }

        //Get the create planet view
        public IActionResult Create()
        {
            return View();
        }

        //Post Route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Planet objPlanet)
        {
            if (ModelState.IsValid)
            {
                _db.Planets.Add(objPlanet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objPlanet);
        }

        //Get the edit planet view
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var characterFromDb = _db.Planets.Find(id);

            if (characterFromDb == null)
            {
                return NotFound();
            }

            return View(characterFromDb);
        }

        //PUT Route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Planet objPlanet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _db.Planets.Update(objPlanet);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objPlanet);
        }

        //Delete Route
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var planetFromDb = _db.Planets.Find(id);

            if (planetFromDb == null)
            {
                return NotFound();
            }

            _db.Planets.Remove(planetFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
