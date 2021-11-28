using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CPVidGameRev.Models;

namespace CPVidGameRev.Controllers
{
    public class GameReviewsController : Controller
    {
        private VidGameRevDBContext db = new VidGameRevDBContext();

        // GET: GameReviews
        public ActionResult Index(string searchWord)
        {
            var titles = from c in db.GameReviews
                         select c;

            if (!String.IsNullOrEmpty(searchWord))
            {
                titles = titles.Where(s => s.GameTitle.Contains(searchWord));
            }
            return View(titles);
        }

        // GET: GameReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameReview gameReview = db.GameReviews.Find(id);
            if (gameReview == null)
            {
                return HttpNotFound();
            }
            return View(gameReview);
        }

        // GET: GameReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameTitle,TimeAdded,ReviewScore,ReviewContent,Reviewer")] GameReview gameReview)
        {
            if (ModelState.IsValid)
            {
                db.GameReviews.Add(gameReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gameReview);
        }

        // GET: GameReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameReview gameReview = db.GameReviews.Find(id);
            if (gameReview == null)
            {
                return HttpNotFound();
            }
            return View(gameReview);
        }

        // POST: GameReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GameTitle,TimeAdded,ReviewScore,ReviewContent,Reviewer")] GameReview gameReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gameReview);
        }

        // GET: GameReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameReview gameReview = db.GameReviews.Find(id);
            if (gameReview == null)
            {
                return HttpNotFound();
            }
            return View(gameReview);
        }

        // POST: GameReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GameReview gameReview = db.GameReviews.Find(id);
            db.GameReviews.Remove(gameReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
