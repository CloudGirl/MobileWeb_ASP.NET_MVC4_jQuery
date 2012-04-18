using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class SessionController : Controller
    {
        private WDD2425Entities db = new WDD2425Entities();

        //
        // GET: /Session/

        public ActionResult Index()
        {
            var sessions = db.Sessions.Include("Timeslots");
            return View(sessions.ToList());
        }

        //
        // GET: /Session/Details/5

        public ActionResult Details(int id = 0)
        {
            Sessions sessions = db.Sessions.Single(s => s.Id == id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        //
        // GET: /Session/Create

        public ActionResult Create()
        {
            ViewBag.Timeslot_Id = new SelectList(db.Timeslots, "Id", "Name");
            return View();
        }

        //
        // POST: /Session/Create

        [HttpPost]
        public ActionResult Create(Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.AddObject(sessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Timeslot_Id = new SelectList(db.Timeslots, "Id", "Name", sessions.Timeslot_Id);
            return View(sessions);
        }

        //
        // GET: /Session/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sessions sessions = db.Sessions.Single(s => s.Id == id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            ViewBag.Timeslot_Id = new SelectList(db.Timeslots, "Id", "Name", sessions.Timeslot_Id);
            return View(sessions);
        }

        //
        // POST: /Session/Edit/5

        [HttpPost]
        public ActionResult Edit(Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Sessions.Attach(sessions);
                db.ObjectStateManager.ChangeObjectState(sessions, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Timeslot_Id = new SelectList(db.Timeslots, "Id", "Name", sessions.Timeslot_Id);
            return View(sessions);
        }

        //
        // GET: /Session/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sessions sessions = db.Sessions.Single(s => s.Id == id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        //
        // POST: /Session/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sessions sessions = db.Sessions.Single(s => s.Id == id);
            db.Sessions.DeleteObject(sessions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}