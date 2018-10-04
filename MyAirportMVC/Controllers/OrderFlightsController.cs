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
    public class OrderFlightsController : Controller
    {
        private AeroportEntities db = new AeroportEntities();

        // GET: OrderFlights
        public ActionResult Index()
        {
            var orderFlight = db.OrderFlight.Include(o => o.Flight).Include(o => o.Passanger);
            return View(orderFlight.ToList());
        }

        // GET: OrderFlights/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderFlight orderFlight = db.OrderFlight.Find(id);
            if (orderFlight == null)
            {
                return HttpNotFound();
            }
            return View(orderFlight);
        }

        // GET: OrderFlights/Create
        public ActionResult Create()
        {
            ViewBag.Flight_Info_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber");
            ViewBag.Passanger_Info_ID = new SelectList(db.Passanger, "Passanger_ID", "FirstName");
            return View();
        }

        // POST: OrderFlights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderFlight_ID,Passanger_Info_ID,Flight_Info_ID,DateTimeOrder")] OrderFlight orderFlight)
        {
            if (ModelState.IsValid)
            {
                orderFlight.OrderFlight_ID = Guid.NewGuid();
                db.OrderFlight.Add(orderFlight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Flight_Info_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber", orderFlight.Flight_Info_ID);
            ViewBag.Passanger_Info_ID = new SelectList(db.Passanger, "Passanger_ID", "FirstName", orderFlight.Passanger_Info_ID);
            return View(orderFlight);
        }

        // GET: OrderFlights/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderFlight orderFlight = db.OrderFlight.Find(id);
            if (orderFlight == null)
            {
                return HttpNotFound();
            }
            ViewBag.Flight_Info_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber", orderFlight.Flight_Info_ID);
            ViewBag.Passanger_Info_ID = new SelectList(db.Passanger, "Passanger_ID", "FirstName", orderFlight.Passanger_Info_ID);
            return View(orderFlight);
        }

        // POST: OrderFlights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderFlight_ID,Passanger_Info_ID,Flight_Info_ID,DateTimeOrder")] OrderFlight orderFlight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderFlight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Flight_Info_ID = new SelectList(db.Flight, "Flight_ID", "FlightNumber", orderFlight.Flight_Info_ID);
            ViewBag.Passanger_Info_ID = new SelectList(db.Passanger, "Passanger_ID", "FirstName", orderFlight.Passanger_Info_ID);
            return View(orderFlight);
        }

        // GET: OrderFlights/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderFlight orderFlight = db.OrderFlight.Find(id);
            if (orderFlight == null)
            {
                return HttpNotFound();
            }
            return View(orderFlight);
        }

        // POST: OrderFlights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OrderFlight orderFlight = db.OrderFlight.Find(id);
            db.OrderFlight.Remove(orderFlight);
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
