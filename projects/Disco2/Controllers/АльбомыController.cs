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
    public class АльбомыController : Controller
    {
        private DiscoContext db = new DiscoContext();

        // GET: Альбомы
        public ActionResult Index()
        {
            var альбомы = db.Альбомы.Include(а => а.Тип);
            return View(альбомы.ToList());
        }

        // GET: Альбомы/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Альбомы альбомы = db.Альбомы.Find(id);
            if (альбомы == null)
            {
                return HttpNotFound();
            }
            return View(альбомы);
        }
        [Authorize]
        // GET: Альбомы/Create
        public ActionResult Create()
        {
            ViewBag.ID_типа = new SelectList(db.Тип, "ID_типа", "Название");
            return View();
        }
        [Authorize]
        // POST: Альбомы/Create
        [HttpPost]
        
        public ActionResult Create([Bind(Include = "ID_альбома,Название,Дата_выпуска,ID_типа")] Альбомы альбомы)
        {
            if (ModelState.IsValid)
            {
                альбомы.ID_альбома = Guid.NewGuid();
                db.Альбомы.Add(альбомы);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_типа = new SelectList(db.Тип, "ID_типа", "Название", альбомы.ID_типа);
            return View(альбомы);
        }
        [Authorize]
        // GET: Альбомы/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Альбомы альбомы = db.Альбомы.Find(id);
            if (альбомы == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_типа = new SelectList(db.Тип, "ID_типа", "Название", альбомы.ID_типа);
            return View(альбомы);
        }
        [Authorize]
        // POST: Альбомы/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID_альбома,Название,Дата_выпуска,ID_типа")] Альбомы альбомы)
        {
            if (ModelState.IsValid)
            {
                db.Entry(альбомы).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_типа = new SelectList(db.Тип, "ID_типа", "Название", альбомы.ID_типа);
            return View(альбомы);
        }
        
        // GET: Альбомы/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Альбомы альбомы = db.Альбомы.Find(id);
            if (альбомы == null)
            {
                return HttpNotFound();
            }
            return View(альбомы);
        }
        
        // POST: Альбомы/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Альбомы альбомы = db.Альбомы.Find(id);
            db.Альбомы.Remove(альбомы);
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
