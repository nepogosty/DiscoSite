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
    public class ТипController : Controller
    {
        private DiscoContext db = new DiscoContext();

        // GET: Тип
        public ActionResult Index()
        {
            return View(db.Тип.ToList());
        }

        // GET: Тип/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тип тип = db.Тип.Find(id);
            if (тип == null)
            {
                return HttpNotFound();
            }
            return View(тип);
        }
        [Authorize]
        // GET: Тип/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Тип/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID_типа,Название")] Тип тип)
        {
            if (ModelState.IsValid)
            {
                db.Тип.Add(тип);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(тип);
        }
        [Authorize]
        // GET: Тип/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тип тип = db.Тип.Find(id);
            if (тип == null)
            {
                return HttpNotFound();
            }
            return View(тип);
        }
        [Authorize]
        // POST: Тип/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID_типа,Название")] Тип тип)
        {
            if (ModelState.IsValid)
            {
                db.Entry(тип).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(тип);
        }
        [Authorize]
        // GET: Тип/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тип тип = db.Тип.Find(id);
            if (тип == null)
            {
                return HttpNotFound();
            }
            return View(тип);
        }
        [Authorize]
        // POST: Тип/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Тип тип = db.Тип.Find(id);
            db.Тип.Remove(тип);
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
