using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rosu.Models;

namespace Rosu.Controllers
{
    public class CommitteesController : Controller
    {
        private FKM52802019Entities2 db = new FKM52802019Entities2();

        // GET: Committees
        public ActionResult Index()
        {
            var committees = db.Committees.Include(c => c.Executive);
            return View(committees.ToList());
        }

        // GET: Committees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Committee committee = db.Committees.Find(id);
            if (committee == null)
            {
                return HttpNotFound();
            }
            return View(committee);
        }

        // GET: Committees/Create
        public ActionResult Create()
        {
            ViewBag.committee_leader = new SelectList(db.Executives, "executiveID", "position");
            return View();
        }

        // POST: Committees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "commiteeID,committee_name,job_description,committee_leader,numberOfMembers")] Committee committee)
        {
            if (ModelState.IsValid)
            {
                db.Committees.Add(committee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.committee_leader = new SelectList(db.Executives, "executiveID", "position", committee.committee_leader);
            return View(committee);
        }

        // GET: Committees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Committee committee = db.Committees.Find(id);
            if (committee == null)
            {
                return HttpNotFound();
            }
            ViewBag.committee_leader = new SelectList(db.Executives, "executiveID", "position", committee.committee_leader);
            return View(committee);
        }

        // POST: Committees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "commiteeID,committee_name,job_description,committee_leader,numberOfMembers")] Committee committee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(committee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.committee_leader = new SelectList(db.Executives, "executiveID", "position", committee.committee_leader);
            return View(committee);
        }

        // GET: Committees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Committee committee = db.Committees.Find(id);
            if (committee == null)
            {
                return HttpNotFound();
            }
            return View(committee);
        }

        // POST: Committees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Committee committee = db.Committees.Find(id);
            db.Committees.Remove(committee);
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
