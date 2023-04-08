using benji_wan_kenobi.Data;
using benji_wan_kenobi.Models;
using Microsoft.AspNetCore.Mvc;

namespace benji_wan_kenobi.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CharacterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Character> objCharacterList = _db.Characters;
            return View(objCharacterList);
        }

        //Get the Create page
        public IActionResult Create()
        {
            return View();
        }

        //Post Route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Character objCharacter)
        {
            if (ModelState.IsValid)
            {
                _db.Characters.Add(objCharacter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objCharacter);
        }

        //Get Edit Character View
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var characterFromDb = _db.Characters.Find(id);

            if (characterFromDb == null)
            {
                return NotFound();
            }

            return View(characterFromDb);
        }

        //PUT Route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Character objCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _db.Characters.Update(objCharacter);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objCharacter);
        }

        //Delete Route
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var characterFromDb = _db.Characters.Find(id);

            if (characterFromDb == null)
            {
                return NotFound();
            }

            _db.Characters.Remove(characterFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
