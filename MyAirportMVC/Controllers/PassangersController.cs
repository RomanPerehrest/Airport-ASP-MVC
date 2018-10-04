using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyAirportMVC.Models;

namespace MyAirportMVC.Controllers
{
    public class PassangersController : Controller
    {
        private AeroportEntities db = new AeroportEntities();

        // GET: Passangers
        public ActionResult Index()
        {
            return View(db.Passanger.ToList());
        }

        // GET: Passangers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passanger passanger = db.Passanger.Find(id);
            if (passanger == null)
            {
                return HttpNotFound();
            }
            return View(passanger);
        }

        // GET: Passangers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passangers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Passanger_ID,FirstName,LastName,Nationality,PassportID,DateOfBirth,Sex")] Passanger passanger)
        {
            if (ModelState.IsValid)
            {
                passanger.Passanger_ID = Guid.NewGuid();
                db.Passanger.Add(passanger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passanger);
        }

        // GET: Passangers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passanger passanger = db.Passanger.Find(id);
            if (passanger == null)
            {
                return HttpNotFound();
            }
            return View(passanger);
        }

        // POST: Passangers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Passanger_ID,FirstName,LastName,Nationality,PassportID,DateOfBirth,Sex")] Passanger passanger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passanger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passanger);
        }

        // GET: Passangers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passanger passanger = db.Passanger.Find(id);
            if (passanger == null)
            {
                return HttpNotFound();
            }
            return View(passanger);
        }

        // POST: Passangers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Passanger passanger = db.Passanger.Find(id);
            db.Passanger.Remove(passanger);
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
