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
    public class LifeguardsController : Controller
    {
        private WebApplication7Context db = new WebApplication7Context();

        // GET: Lifeguards
        public ActionResult Index(string SearchName, string City, string Gender, String Status)
        {
            //Search by city
            var cityList = new List<string>();
            var cityQuery = from c in db.Lifeguards orderby c.city.city_name select c.city.city_name;

            cityList.AddRange(cityQuery.Distinct());
            ViewBag.City = new SelectList(cityList);

            //Search by Gender
            var genderList = new List<string>();
            var genderQuery = from g in db.Lifeguards orderby g.Gender select g.Gender;

            genderList.AddRange(genderQuery.Distinct());
            ViewBag.Gender = new SelectList(genderList);

            //Search by Status
            var statusList = new List<string>();
            var statusQuery = from s in db.Lifeguards orderby s.l_status select s.l_status;

            statusList.AddRange(statusQuery.Distinct());
            ViewBag.Status = new SelectList(statusList);

            //Search by name
            var lifeguards = from lg in db.Lifeguards select lg;

            //includes city 
            lifeguards = db.Lifeguards.Include(l => l.city);

            //Search by name
            if (!String.IsNullOrEmpty(SearchName))
            {
                lifeguards = lifeguards.Where(x => x.lifeguard_name.Contains(SearchName));
            }

            //Search by City
            if (!String.IsNullOrEmpty(City))
            {
                lifeguards = lifeguards.Where(x => x.city.city_name == City);
            }

            //Search by gender
            if (!String.IsNullOrEmpty(Gender))
            {
                lifeguards = lifeguards.Where(x => x.Gender == Gender);
            }

            //Search by Status
            if (!String.IsNullOrEmpty(Status))
            {
                lifeguards = lifeguards.Where(x => x.l_status == Status);
            }



            return View(lifeguards);
        }

        // GET: Lifeguards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifeguards lifeguards = db.Lifeguards.Find(id);
            if (lifeguards == null)
            {
                return HttpNotFound();
            }
            return View(lifeguards);
        }

        // GET: Lifeguards/Create
        public ActionResult Create()
        {
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name");
            return View();
        }

        // POST: Lifeguards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lifeguard_id,lifeguard_name,DOB,Gender,l_status,city_id")] Lifeguards lifeguards)
        {
            if (ModelState.IsValid)
            {
                db.Lifeguards.Add(lifeguards);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", lifeguards.city_id);
            return View(lifeguards);
        }

        // GET: Lifeguards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifeguards lifeguards = db.Lifeguards.Find(id);
            if (lifeguards == null)
            {
                return HttpNotFound();
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", lifeguards.city_id);
            return View(lifeguards);
        }

        // POST: Lifeguards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lifeguard_id,lifeguard_name,DOB,Gender,l_status,city_id")] Lifeguards lifeguards)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lifeguards).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city_id = new SelectList(db.Cities, "city_id", "city_name", lifeguards.city_id);
            return View(lifeguards);
        }

        // GET: Lifeguards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lifeguards lifeguards = db.Lifeguards.Find(id);
            if (lifeguards == null)
            {
                return HttpNotFound();
            }
            return View(lifeguards);
        }

        // POST: Lifeguards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lifeguards lifeguards = db.Lifeguards.Find(id);
            db.Lifeguards.Remove(lifeguards);
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
