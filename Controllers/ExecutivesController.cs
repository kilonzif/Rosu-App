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
    public class ExecutivesController : Controller
    {
        private FKM52802019Entities2 db = new FKM52802019Entities2();

        // GET: Executives
        public ActionResult Index()
        {
            var executives = db.Executives.Include(e => e.studentLeader);
            return View(executives.ToList());
        }

        // GET: Executives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Executive executive = db.Executives.Find(id);
            if (executive == null)
            {
                return HttpNotFound();
            }
            return View(executive);
        }

        // GET: Executives/Create
        public ActionResult Create()
        {
            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName");
            return View();
        }

        // POST: Executives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "executiveID,studentID,position,staffPartner")] Executive executive)
        {
            if (ModelState.IsValid)
            {
                db.Executives.Add(executive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName", executive.studentID);
            return View(executive);
        }

        // GET: Executives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Executive executive = db.Executives.Find(id);
            if (executive == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName", executive.studentID);
            return View(executive);
        }

        // POST: Executives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "executiveID,studentID,position,staffPartner")] Executive executive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(executive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentID = new SelectList(db.studentLeaders, "studentID", "firstName", executive.studentID);
            return View(executive);
        }

        // GET: Executives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Executive executive = db.Executives.Find(id);
            if (executive == null)
            {
                return HttpNotFound();
            }
            return View(executive);
        }

        // POST: Executives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Executive executive = db.Executives.Find(id);
            db.Executives.Remove(executive);
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
