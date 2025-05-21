using HW13_Notes_MVC.Data;
using HW13_Notes_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW13_Notes_MVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly NotesMvcDbContext _context;

        public NoteController(NotesMvcDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> notes = _context.Notes;

            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
