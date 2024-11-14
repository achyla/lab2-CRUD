using Lab2_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2_CRUD.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis filmu1", Price=10},
            new Film(){Id = 2, Name = "Film2", Description = "opis filmu2", Price=50},
            new Film(){Id = 3, Name = "Film3", Description = "opis filmu3", Price=80},
        };
        // GET: FilmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film FilmDoEdycji = films.FirstOrDefault(x => x.Id == id);
            if (FilmDoEdycji != null)
            {
                FilmDoEdycji.Name = film.Name;
                FilmDoEdycji.Description = film.Description;
                FilmDoEdycji.Price = film.Price;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                films.Remove(film);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
