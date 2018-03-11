using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Entity.Models;

namespace MVC_Entity.Controllers {
    [Authorize]
    public class StaysController : Controller {
        private MVC_EntityContext db = new MVC_EntityContext();

        // GET: Stays this will show all stays
        public ActionResult Index() {
            var stays = db.Stays.Include(s => s.client).Include(s => s.room);
            return View(stays.ToList());
        }

        //list the stays not terminated
        public ActionResult ListStays() {
            var stays = db.Stays.Where(s => s.cost_paid==0).Include(s => s.client).Include(s => s.room);
            return View(stays.ToList());
        }
        //show the stay info
        public ActionResult ExitStay(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stay stay = db.Stays.Find(id);
            if (stay == null) {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "nome", stay.ClientId);
            ViewBag.nr = new SelectList(db.Rooms, "nr", "nr", stay.nr);
            //client data
            var clientData = db.Clients.Find(stay.ClientId);
            ViewBag.clientData = clientData;
            //room data and stay cost
            var roomData = db.Rooms.Find(stay.nr);
            ViewBag.roomData = roomData;
            TimeSpan timeSpan = DateTime.Now.Date.Subtract(stay.EntryDate.Date);
            ViewBag.timeSpan = Math.Abs(timeSpan.TotalDays);
            stay.cost_paid = (decimal)timeSpan.TotalDays * roomData.custo_dia;
            stay.ExitDate = DateTime.Now.Date;
            return View(stay);
        }
        //process the stay info
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExitStay([Bind(Include = "StayId,EntryDate,ExitDate,cost_paid,ClientId,nr")] Stay stay) {
            if (ModelState.IsValid) {
                db.Entry(stay).State = EntityState.Modified;
                stay.ExitDate = DateTime.Now.Date;
                //change the room state
                var room = db.Rooms.Find(stay.nr);
                room.estado = true;
                db.Entry(room).CurrentValues.SetValues(room);
                //save all changes
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "nome", stay.ClientId);
            ViewBag.nr = new SelectList(db.Rooms, "nr", "nr", stay.nr);
            //client data
            var clientData = db.Clients.Find(stay.ClientId);
            ViewBag.clientData = clientData;
            //room data and stay cost
            var roomData = db.Rooms.Find(stay.nr);
            ViewBag.roomData = roomData;
            TimeSpan timeSpan = DateTime.Now.Date.Subtract(stay.EntryDate.Date);
            ViewBag.timeSpan = Math.Abs(timeSpan.TotalDays);
            stay.cost_paid = (decimal)timeSpan.TotalDays * roomData.custo_dia;
            stay.ExitDate = DateTime.Now.Date;
            return View(stay);
        }

        // GET: Stays/Create this will create a new stay
        public ActionResult Create() {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "nome");
            //only show empty rooms
            ViewBag.nr = new SelectList(db.Rooms.Where(r=>r.estado==true), "nr", "nr");
            return View();
        }

        // POST: Stays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StayId,EntryDate,ExitDate,cost_paid,ClientId,nr")] Stay stay) {
            if (ModelState.IsValid) {
                stay.ExitDate = stay.EntryDate;
                db.Stays.Add(stay);
                //change the room state
                var room = db.Rooms.Find(stay.nr);
                room.estado = false;
                db.Entry(room).CurrentValues.SetValues(room);
                //save all changes
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "nome", stay.ClientId);
            ViewBag.nr = new SelectList(db.Rooms.Where(r => r.estado==true), "nr", "nr", stay.nr);
            return View(stay);
        }

              // GET: Stays/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stay stay = db.Stays.Find(id);
            if (stay == null) {
                return HttpNotFound();
            }
            return View(stay);
        }

        // POST: Stays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Stay stay = db.Stays.Find(id);
            db.Stays.Remove(stay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
