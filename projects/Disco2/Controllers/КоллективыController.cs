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
    public class КоллективыController : Controller
    {
        private DiscoContext db = new DiscoContext();

        // GET: Коллективы
        public ActionResult Index()
        {
            var коллективы = db.Коллективы.Include(к => к.Тип_коллектива);
            return View(коллективы.ToList());
        }

        // GET: Коллективы/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Коллективы коллективы = db.Коллективы.Find(id);
            if (коллективы == null)
            {
                return HttpNotFound();
            }
            //Коллективы коллективы1 = db.Коллективы.FirstOrDefault(p => p.ID_коллектива == id);
            //var co = db.Исполнение_композиций.Select(p => p.Альбомы.Select(s => s.Название));
            //return View(коллективы1);

                         return View(коллективы);
        }
        [Authorize]
        // GET: Коллективы/Create
        public ActionResult Create()
        {
            ViewBag.ID_типа_коллектива = new SelectList(db.Тип_коллектива, "ID_типа_коллектива", "Наименование");
            return View();
        }

        // POST: Коллективы/Create
     
        [HttpPost]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID_коллектива,Страна,Название,ID_типа_коллектива,Год_создания")] Коллективы коллективы)
        {
            if (ModelState.IsValid)
            {
                коллективы.ID_коллектива = Guid.NewGuid();
                db.Коллективы.Add(коллективы);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_типа_коллектива = new SelectList(db.Тип_коллектива, "ID_типа_коллектива", "Наименование", коллективы.ID_типа_коллектива);
            return View(коллективы);
        }
        [Authorize]
        // GET: Коллективы/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Коллективы коллективы = db.Коллективы.Find(id);
            if (коллективы == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_типа_коллектива = new SelectList(db.Тип_коллектива, "ID_типа_коллектива", "Наименование", коллективы.ID_типа_коллектива);
            return View(коллективы);
        }
        [Authorize]
        // POST: Коллективы/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID_коллектива,Страна,Название,ID_типа_коллектива,Год_создания")] Коллективы коллективы)
        {
            if (ModelState.IsValid)
            {
                db.Entry(коллективы).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_типа_коллектива = new SelectList(db.Тип_коллектива, "ID_типа_коллектива", "Наименование", коллективы.ID_типа_коллектива);
            return View(коллективы);
        }
        [Authorize]
        // GET: Коллективы/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Коллективы коллективы = db.Коллективы.Find(id);
            if (коллективы == null)
            {
                return HttpNotFound();
            }
            return View(коллективы);
        }
        [Authorize]
        // POST: Коллективы/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(Guid id)
        {
            Коллективы коллективы = db.Коллективы.Find(id);
            db.Коллективы.Remove(коллективы);
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
