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
    public class CommitteeMembersController : Controller
    {
        private FKM52802019Entities2 db = new FKM52802019Entities2();

        // GET: CommitteeMembers
        public ActionResult Index()
        {
            var committeeMembers = db.CommitteeMembers.Include(c => c.Committee);
            return View(committeeMembers.ToList());
        }

        // GET: CommitteeMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            if (committeeMember == null)
            {
                return HttpNotFound();
            }
            return View(committeeMember);
        }

        // GET: CommitteeMembers/Create
        public ActionResult Create()
        {
            ViewBag.memberCommittee = new SelectList(db.Committees, "commiteeID", "committee_name");
            return View();
        }

        // POST: CommitteeMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentID,memberCommittee,class_represented")] CommitteeMember committeeMember)
        {
            if (ModelState.IsValid)
            {
                db.CommitteeMembers.Add(committeeMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberCommittee = new SelectList(db.Committees, "commiteeID", "committee_name", committeeMember.memberCommittee);
            return View(committeeMember);
        }

        // GET: CommitteeMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            if (committeeMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberCommittee = new SelectList(db.Committees, "commiteeID", "committee_name", committeeMember.memberCommittee);
            return View(committeeMember);
        }

        // POST: CommitteeMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentID,memberCommittee,class_represented")] CommitteeMember committeeMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(committeeMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberCommittee = new SelectList(db.Committees, "commiteeID", "committee_name", committeeMember.memberCommittee);
            return View(committeeMember);
        }

        // GET: CommitteeMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            if (committeeMember == null)
            {
                return HttpNotFound();
            }
            return View(committeeMember);
        }

        // POST: CommitteeMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommitteeMember committeeMember = db.CommitteeMembers.Find(id);
            db.CommitteeMembers.Remove(committeeMember);
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
