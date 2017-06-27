using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerScienceTsu.Models.Generated;

namespace ComputerScienceTsu.Controllers
{
    public class CS_DepartmentsController : Controller
    {
        private TsuModel db = new TsuModel();

        // GET: CS_Departments
        public ActionResult Index()
        {
            return View(db.CS_Departments.ToList());
        }

        // GET: CS_Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CS_Departments cS_Departments = db.CS_Departments.Find(id);
            if (cS_Departments == null)
            {
                return HttpNotFound();
            }
            return View(cS_Departments);
        }

        // GET: CS_Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CS_Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Id_name")] CS_Departments cS_Departments)
        {
            if (ModelState.IsValid)
            {
                db.CS_Departments.Add(cS_Departments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cS_Departments);
        }

        // GET: CS_Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CS_Departments cS_Departments = db.CS_Departments.Find(id);
            if (cS_Departments == null)
            {
                return HttpNotFound();
            }
            return View(cS_Departments);
        }

        // POST: CS_Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Id_name")] CS_Departments cS_Departments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cS_Departments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cS_Departments);
        }

        // GET: CS_Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CS_Departments cS_Departments = db.CS_Departments.Find(id);
            if (cS_Departments == null)
            {
                return HttpNotFound();
            }
            return View(cS_Departments);
        }

        // POST: CS_Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CS_Departments cS_Departments = db.CS_Departments.Find(id);
            db.CS_Departments.Remove(cS_Departments);
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
