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
    public class МузыкантыController : Controller
    {
        private DiscoContext db = new DiscoContext();

        // GET: Музыканты
        public ActionResult Index()
        {
            return View(db.Музыканты.ToList());
        }

        // GET: Музыканты/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Музыканты музыканты = db.Музыканты.FirstOrDefault(p => p.ID_музыканта == id);
            if (музыканты == null)
            {
                return HttpNotFound();
            }
            return View(музыканты);
        }
        [Authorize]
        // GET: Музыканты/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Музыканты/Create
       [HttpPost]
        
        public ActionResult Create([Bind(Include = "ID_музыканта,Фамилия,Имя,Отчество,Гражданство")] Музыканты музыканты)
        {
            if (ModelState.IsValid)
            {
                музыканты.ID_музыканта = Guid.NewGuid();
                db.Музыканты.Add(музыканты);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(музыканты);
        }
        [Authorize]
        // GET: Музыканты/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Музыканты музыканты = db.Музыканты.Find(id);
            if (музыканты == null)
            {
                return HttpNotFound();
            }
            return View(музыканты);
        }
        [Authorize]
        // POST: Музыканты/Edit/5
        [HttpPost]
        
        public ActionResult Edit([Bind(Include = "ID_музыканта,Фамилия,Имя,Отчество,Гражданство")] Музыканты музыканты)
        {
            if (ModelState.IsValid)
            {
                db.Entry(музыканты).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(музыканты);
        }
        [Authorize]
        // GET: Музыканты/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Музыканты музыканты = db.Музыканты.Find(id);
            if (музыканты == null)
            {
                return HttpNotFound();
            }
            return View(музыканты);
        }
        [Authorize]
        // POST: Музыканты/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Музыканты музыканты = db.Музыканты.Find(id);
            db.Музыканты.Remove(музыканты);
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
