using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Disco2.Models;

namespace Disco2.Controllers
{
    public class ЖанрыController : Controller
    {
        private DiscoContext db = new DiscoContext();

        // GET: Жанры
        public ActionResult Index()
        {

            return View(db.Жанры.ToList());
        }
        
        // GET: Жанры/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Жанры жанры = db.Жанры.Find(id);
            if (жанры == null)
            {
                return HttpNotFound();
            }
            return View(жанры);
        }
        [Authorize]
        // GET: Жанры/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Жанры/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID_жанра,Название")] Жанры жанры)
        {
            if (ModelState.IsValid)
            {
                db.Жанры.Add(жанры);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(жанры);
        }
        [Authorize]
        // GET: Жанры/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Жанры жанры = db.Жанры.Find(id);
            if (жанры == null)
            {
                return HttpNotFound();
            }
            return View(жанры);
        }
        [Authorize]
        // POST: Жанры/Edit/5
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_жанра,Название")] Жанры жанры)
        {
            if (ModelState.IsValid)
            {
                db.Entry(жанры).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(жанры);
        }
        [Authorize]
        // GET: Жанры/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Жанры жанры = db.Жанры.Find(id);
            if (жанры == null)
            {
                return HttpNotFound();
            }
            return View(жанры);
        }
        [Authorize]
        // POST: Жанры/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Жанры жанры = db.Жанры.Find(id);
            db.Жанры.Remove(жанры);
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
