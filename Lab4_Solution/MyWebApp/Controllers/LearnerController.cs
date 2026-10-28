using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // 8.1 LIST (R)
        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }

        // 8.2 CREATE (C)
        public IActionResult Create()
        {
            // Cách 1: tự tạo List<SelectListItem>
            var majors = new List<SelectListItem>();
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                });
            }
            ViewBag.MajorID = majors;

            // Cách 2: dùng SelectList (ghi đè cách 1, chỉ cần dùng 1 trong 2 cách)
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View(new Learner { EnrollmentDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            // Dựng lại SelectList để hiển thị danh sách Majors
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View(learner);
        }

        // 8.3 UPDATE (U)
        public IActionResult Edit(int id)
        {
            if (db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,
            [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        private bool LearnerExists(int id)
        {
            return db.Learners.Any(e => e.LearnerID == id);
        }

        // 8.4 DELETE (D)
        public IActionResult Delete(int id)
        {
            if (db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);
            if (learner == null)
            {
                return NotFound();
            }
            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }
            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
