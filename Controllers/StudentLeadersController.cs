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
    public class StudentLeadersController : Controller
    {
        private FKM52802019Entities2 db = new FKM52802019Entities2();

        // GET: StudentLeaders
        public ActionResult Index()
        {
            return View(db.studentLeaders.ToList());
        }

        // GET: StudentLeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentLeader studentLeader = db.studentLeaders.Find(id);
            if (studentLeader == null)
            {
                return HttpNotFound();
            }
            return View(studentLeader);
        }

        // GET: StudentLeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentLeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentID,firstName,lastName,gender,major,gpa,email,phoneNumber")] studentLeader studentLeader)
        {
            if (ModelState.IsValid)
            {
                db.studentLeaders.Add(studentLeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentLeader);
        }

        // GET: StudentLeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentLeader studentLeader = db.studentLeaders.Find(id);
            if (studentLeader == null)
            {
                return HttpNotFound();
            }
            return View(studentLeader);
        }

        // POST: StudentLeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentID,firstName,lastName,gender,major,gpa,email,phoneNumber")] studentLeader studentLeader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentLeader);
        }

        // GET: StudentLeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            studentLeader studentLeader = db.studentLeaders.Find(id);
            if (studentLeader == null)
            {
                return HttpNotFound();
            }
            return View(studentLeader);
        }

        // POST: StudentLeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentLeader studentLeader = db.studentLeaders.Find(id);
            db.studentLeaders.Remove(studentLeader);
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
