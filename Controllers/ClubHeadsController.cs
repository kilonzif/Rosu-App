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
    public class ClubHeadsController : Controller
    {
        private FKM52802019Entities2 db = new FKM52802019Entities2();

        // GET: ClubHeads
        public ActionResult Index()
        {
            var clubHeads = db.clubHeads.Include(c => c.studentLeader);
            return View(clubHeads.ToList());
        }

        // GET: ClubHeads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubHead clubHead = db.clubHeads.Find(id);
            if (clubHead == null)
            {
                return HttpNotFound();
            }
            return View(clubHead);
        }

        // GET: ClubHeads/Create
        public ActionResult Create()
        {
            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName");
            return View();
        }

        // POST: ClubHeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clubheadID,studentID,salaryAllowance,departmentPartner")] clubHead clubHead)
        {
            if (ModelState.IsValid)
            {
                db.clubHeads.Add(clubHead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName", clubHead.studentID);
            return View(clubHead);
        }

        // GET: ClubHeads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubHead clubHead = db.clubHeads.Find(id);
            if (clubHead == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName", clubHead.studentID);
            return View(clubHead);
        }

        // POST: ClubHeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clubheadID,studentID,salaryAllowance,departmentPartner")] clubHead clubHead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubHead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName", clubHead.studentID);
            return View(clubHead);
        }

        // GET: ClubHeads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clubHead clubHead = db.clubHeads.Find(id);
            if (clubHead == null)
            {
                return HttpNotFound();
            }
            return View(clubHead);
        }

        // POST: ClubHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clubHead clubHead = db.clubHeads.Find(id);
            db.clubHeads.Remove(clubHead);
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
