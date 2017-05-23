using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerScienceTsu.Models.Generated;
using ComputerScienceTsu.Services;
using System.IO;

namespace ComputerScienceTsu.Views
{
    public class LecturersController : Controller
    {
        private TsuModel db = new TsuModel();

        // GET: Lecturers
        public ActionResult Index()
        {
            var lecturers = db.Lecturers.Include(l => l.Photo);
            return View(lecturers.ToList());
        }

        // GET: Lecturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // GET: Lecturers/Create
        public ActionResult Create()
        {
            ViewBag.Photo_id = new SelectList(db.Photos, "ID", "Image_path");
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name, string Lastname, string Phone, string Email, string About, string Additional_info, string Full_address, HttpPostedFileBase file)
        {
            string alternativePath = @"/Content/images/" + file.FileName;
            var photo = LecturersService.SetPhoto(alternativePath);
            file.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), file.FileName));
            if (photo != null)
            {
                db.Photos.Add(photo);
                db.SaveChanges();
            }

            var lecturer = LecturersService.SetLecturer(Name, Lastname, Phone, Email, About, Additional_info, photo.ID, Full_address);

            if (ModelState.IsValid)
            {
                db.Lecturers.Add(lecturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Photo_id = new SelectList(db.Photos, "ID", "Image_path", lecturer.Photo_id);
            return View(lecturer);
        }

        // GET: Lecturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Photo_id = new SelectList(db.Photos, "ID", "Image_path", lecturer.Photo_id);
            return View(lecturer);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Lastname,Phone,Email,About,Additional_info,Photo_id,Full_address")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Photo_id = new SelectList(db.Photos, "ID", "Image_path", lecturer.Photo_id);
            return View(lecturer);
        }

        // GET: Lecturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecturer lecturer = db.Lecturers.Find(id);
            db.Lecturers.Remove(lecturer);
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
