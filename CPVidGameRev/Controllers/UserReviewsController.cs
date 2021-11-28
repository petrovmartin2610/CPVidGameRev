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
    public class UserReviewsController : Controller
    {
        private VidGameRevDBContext db = new VidGameRevDBContext();

        // GET: UserReviews
        public ActionResult Index(string searchWord)
        {
            var reviews = from c in db.UserReviews
                         select c;

            if (!String.IsNullOrEmpty(searchWord))
            {
                reviews = reviews.Where(s => s.UserName.Contains(searchWord));
            }
            return View(reviews);
        }

        // GET: UserReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReview userReview = db.UserReviews.Find(id);
            if (userReview == null)
            {
                return HttpNotFound();
            }
            return View(userReview);
        }

        // GET: UserReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,TimeAdded,ReviewContent,UserReviewScore,NumberOfReviewedGames")] UserReview userReview)
        {
            if (ModelState.IsValid)
            {
                db.UserReviews.Add(userReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userReview);
        }

        // GET: UserReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReview userReview = db.UserReviews.Find(id);
            if (userReview == null)
            {
                return HttpNotFound();
            }
            return View(userReview);
        }

        // POST: UserReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,TimeAdded,ReviewContent,UserReviewScore,NumberOfReviewedGames")] UserReview userReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userReview);
        }

        // GET: UserReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserReview userReview = db.UserReviews.Find(id);
            if (userReview == null)
            {
                return HttpNotFound();
            }
            return View(userReview);
        }

        // POST: UserReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserReview userReview = db.UserReviews.Find(id);
            db.UserReviews.Remove(userReview);
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
