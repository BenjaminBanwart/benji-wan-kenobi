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
    }
}
