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

        //Get the page
        public IActionResult Create()
        {
            return View();
        }

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
    }
}
