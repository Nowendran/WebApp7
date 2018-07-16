using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class EquipmentRentalsController : Controller
    {
        private WebApplication7Context db = new WebApplication7Context();

        // GET: EquipmentRentals
        public ActionResult Index()
        {
            
            var equipmentRentals = db.EquipmentRentals.Include(e => e.Equipment).Include(e => e.Lifeguards).Include(e => e.Warehouse);
            return View(equipmentRentals.ToList());
        }

        // GET: EquipmentRentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentRental equipmentRental = db.EquipmentRentals.Find(id);
            if (equipmentRental == null)
            {
                return HttpNotFound();
            }
            return View(equipmentRental);
        }

        // GET: EquipmentRentals/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(x=>x.Status== ("Available")), "EquipmentID", "itemName");
            ViewBag.lifeguard_id = new SelectList(db.Lifeguards, "lifeguard_id", "lifeguard_name");
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName");
            return View();
        }


        //public ActionResult SMD(int WarehouseID)
        //{
        //    db.Configuration.ProxyCreationEnabled = true;
        //    List<Equipment> equipmentList = db.Equipments.Where(x => x.WarehouseID == WarehouseID && x.Status == ("Available")).ToList();
        //    return Json(equipmentList, JsonRequestBehavior.AllowGet);
        //}
        // POST: EquipmentRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipmentRentalID,EquipmentID,WarehouseID,lifeguard_id,ReturnDate,DateOfLoan,Return")] EquipmentRental equipmentRental)
        {

            if (ModelState.IsValid)
            {


                

                    var a = db.Equipments.Find(equipmentRental.EquipmentID);
                    a.Status = "onloan";



                    db.Entry(a).State = EntityState.Modified;

                    equipmentRental.DateOfLoan = DateTime.Now;
                    db.EquipmentRentals.Add(equipmentRental);
                    db.SaveChanges();
                    return RedirectToAction("Index");
               
            }
            //List<Warehouse>warehouses = db.Warehouses.ToList();
            //ViewBag.WarehouseID = new SelectList(warehouses, "WarehouseID", "WarehouseName", equipmentRental.WarehouseID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "itemName", equipmentRental.EquipmentID);
            ViewBag.lifeguard_id = new SelectList(db.Lifeguards, "lifeguard_id", "lifeguard_name", equipmentRental.lifeguard_id);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", equipmentRental.WarehouseID);
            return View(equipmentRental);
        }

        // GET: EquipmentRentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentRental equipmentRental = db.EquipmentRentals.Find(id);
            if (equipmentRental == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "itemName", equipmentRental.EquipmentID);
            ViewBag.lifeguard_id = new SelectList(db.Lifeguards, "lifeguard_id", "lifeguard_name", equipmentRental.lifeguard_id);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", equipmentRental.WarehouseID);
            return View(equipmentRental);
        }

        // POST: EquipmentRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipmentRentalID,EquipmentID,WarehouseID,lifeguard_id,ReturnDate,DateOfLoan,Return")] EquipmentRental equipmentRental)
        {
            if (ModelState.IsValid)
            {
                equipmentRental.DateOfLoan = DateTime.Now;

                db.Entry(equipmentRental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "itemName", equipmentRental.EquipmentID);
            ViewBag.lifeguard_id = new SelectList(db.Lifeguards, "lifeguard_id", "lifeguard_name", equipmentRental.lifeguard_id);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", equipmentRental.WarehouseID);

            return View(equipmentRental);
        }

        // GET: EquipmentRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentRental equipmentRental = db.EquipmentRentals.Find(id);
            if (equipmentRental == null)
            {
                return HttpNotFound();
            }
            return View(equipmentRental);
        }

        // POST: EquipmentRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentRental equipmentRental = db.EquipmentRentals.Find(id);
            db.EquipmentRentals.Remove(equipmentRental);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Return(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EquipmentRental equipmentRental = db.EquipmentRentals.Find(id);
        //    if (equipmentRental == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(equipmentRental);
        //}
        //[HttpPost, ActionName("Return")]
        //[ValidateAntiForgeryToken]
        public ActionResult Return( int? id)
        {
          var equipmentRental = db.EquipmentRentals.Find(id);

           
                var a = db.Equipments.Find(equipmentRental.EquipmentID);
                if (a.Status != "Available")
                {
                if (DateTime.Now.Date > equipmentRental.ReturnDate)
                {
                    a.Status = "OverDue";
                }

                else
                {
                    a.Status = "Available";
                }
                }


                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            
            //ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "itemName", equipmentRental.EquipmentID);
            //ViewBag.lifeguard_id = new SelectList(db.Lifeguards, "lifeguard_id", "lifeguard_name", equipmentRental.lifeguard_id);
            //ViewBag.WarehouseID = new SelectList(db.Warehouses, "WarehouseID", "WarehouseName", equipmentRental.WarehouseID);

            //return View(equipmentRental);
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
