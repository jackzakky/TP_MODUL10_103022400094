using Microsoft.AspNetCore.Mvc;
using TP_MODUL10_103022400094.Models;

namespace TP_MODUL10_103022400094.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private static List<Film> _listFilm = new List<Film>
        {
            new Film("Inception", "Christopher Nolan", "2010", "Sci-Fi", "9.0"),
            new Film("Interstellar", "Christopher Nolan", "2014", "Sci-Fi", "8.7"),
            new Film("Parasite", "Bong Joon-ho", "2019", "Thriller", "8.6")
        };

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _listFilm;
        }

        [HttpGet("{id}")]
        public ActionResult<Film> Get(int id)
        {
            if (id < 0 || id >= _listFilm.Count) return NotFound();
            return _listFilm[id];
        }

        [HttpPost]
        public void Post([FromBody] Film newFilm)
        {
            _listFilm.Add(newFilm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= _listFilm.Count) return NotFound();
            _listFilm.RemoveAt(id);
            return Ok();
        }
    }
}