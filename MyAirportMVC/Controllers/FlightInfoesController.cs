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
    public class FlightInfoesController : Controller
    {
        private AeroportEntities db = new AeroportEntities();

        // GET: FlightInfoes
        public ActionResult Index()
        {
            var flightInfo = db.FlightInfo.Include(f => f.Flight);
            return View(flightInfo.ToList());
        }

        // GET: FlightInfoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfo.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            return View(flightInfo);
        }

        // GET: FlightInfoes/Create
        public ActionResult Create()
        {
            ViewBag.Flight_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber");
            return View();
        }

        [HttpGet]
        public ActionResult Getinfo(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            AeroportEntities aeroport = new AeroportEntities();
            List<FlightInfo> fi = aeroport.FlightInfo.Where(x => x.Flight_ID == id).ToList();

            return View("Index12", fi);
        }

        // POST: FlightInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Flight_Info_ID,Flight_ID,Way,Price")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                flightInfo.Flight_Info_ID = Guid.NewGuid();
                db.FlightInfo.Add(flightInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber", flightInfo.Flight_ID);
            return View(flightInfo);
        }

        // GET: FlightInfoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfo.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flight_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber", flightInfo.Flight_ID);
            return View(flightInfo);
        }

        // POST: FlightInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Flight_Info_ID,Flight_ID,Way,Price")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber", flightInfo.Flight_ID);
            return View(flightInfo);
        }

        // GET: FlightInfoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightInfo flightInfo = db.FlightInfo.Find(id);
            if (flightInfo == null)
            {
                return HttpNotFound();
            }
            return View(flightInfo);
        }

        // POST: FlightInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FlightInfo flightInfo = db.FlightInfo.Find(id);
            db.FlightInfo.Remove(flightInfo);
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
