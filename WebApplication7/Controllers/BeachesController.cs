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
    public class BeachesController : Controller
    {
        private WebApplication7Context db = new WebApplication7Context();

        // GET: Beaches
        public ActionResult Index(string SearchName, string Beach)
        {
            //Search by city
            var cityList = new List<string>();
            var cityQuery = from b in db.Beaches orderby b.city.city_name select b.city.city_name;

            cityList.AddRange(cityQuery.Distinct());
            ViewBag.Beach = new SelectList(cityList);

            //Search by name
            var Beaches = from beach in db.Beaches select beach;

            //includes city
            Beaches = db.Beaches.Include(b => b.city);


            //Search by beach name
            if (!String.IsNullOrEmpty(SearchName))
            {
                Beaches = Beaches.Where(x => x.beach_name.Contains(SearchName));
            }

            //Search by City
            if (!String.IsNullOrEmpty(Beach))
            {
                Beaches = Beaches.Where(x => x.city.city_name.Contains(Beach));
            }


            return View(Beaches);
        }

        // GET: Beaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beach beach = db.Beaches.Find(id);
            if (beach == null)
            {
                return HttpNotFound();
            }
            return View(beach);
        }

        // GET: Beaches/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            return View();
        }

        // POST: Beaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "beach_id,beach_name,city_id")] Beach beach)
        {
            if (ModelState.IsValid)
            {
                db.Beaches.Add(beach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", beach.city_id);
            return View(beach);
        }

        // GET: Beaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beach beach = db.Beaches.Find(id);
            if (beach == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", beach.city_id);
            return View(beach);
        }

        // POST: Beaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "beach_id,beach_name,city_id")] Beach beach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", beach.city_id);
            return View(beach);
        }

        // GET: Beaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beach beach = db.Beaches.Find(id);
            if (beach == null)
            {
                return HttpNotFound();
            }
            return View(beach);
        }

        // POST: Beaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Beach beach = db.Beaches.Find(id);
            db.Beaches.Remove(beach);
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
