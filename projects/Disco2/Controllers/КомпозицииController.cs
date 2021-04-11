using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Disco2.Models;

namespace Disco2.Controllers
{
    public class КомпозицииController : Controller
    {
        private DiscoContext db = new DiscoContext();

        // GET: Композиции
        public ActionResult Index()
        {
            var композиции = db.Композиции.Include(к => к.Жанры);
            return View(композиции.ToList());
        }

        // GET: Композиции/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Композиции композиции = db.Композиции.FirstOrDefault(p=>p.ID_композиции==id);

            if (композиции == null)
            {
                return HttpNotFound();
            }
            return View(композиции);
        }

        // GET: Композиции/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ID_жанра = new SelectList(db.Жанры, "ID_жанра", "Название");
            ViewBag.ID_музыканта = new SelectList(db.Музыканты, "ID_музыканта", "Фамилия");
            ViewBag.Музыканты = db.Музыканты.ToList();
            return View();
        }
        [Authorize]
        // POST: Композиции/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID_композиции,Название,Год_выпуска,ID_жанра,ID_музыканта")] Композиции композиции)
        {
            if (ModelState.IsValid)
            {
               
                
                композиции.ID_композиции = Guid.NewGuid();
                db.Композиции.Add(композиции);
                db.SaveChanges();
               
                var музыкант1 = db.Музыканты.FirstOrDefault(p => p.ID_музыканта == композиции.ID_музыканта);
               
                музыкант1.Авторы.Add(композиции);
                музыкант1.Композиторы.Add(композиции);
                композиции.Авторы.Add(музыкант1);
                композиции.Композиторы.Add(музыкант1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_жанра = new SelectList(db.Жанры, "ID_жанра", "Название", композиции.ID_жанра);
            return View(композиции);
        }
        [Authorize]

        // GET: Композиции/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Композиции композиции = db.Композиции.Find(id);
            if (композиции == null)
            {
                return HttpNotFound();
            }
            ViewBag.Музыканты = db.Музыканты.ToList();
            ViewBag.ID_жанра = new SelectList(db.Жанры, "ID_жанра", "Название", композиции.ID_жанра);
            return View(композиции);
        }
        [Authorize]

        // POST: Композиции/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID_композиции,Название,Год_выпуска,ID_жанра")] Композиции композиции)
        {
            if (ModelState.IsValid)
            {
                db.Entry(композиции).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_жанра = new SelectList(db.Жанры, "ID_жанра", "Название", композиции.ID_жанра);
            return View(композиции);
        }
        [Authorize]
        // GET: Композиции/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Композиции композиции = db.Композиции.Find(id);
            if (композиции == null)
            {
                return HttpNotFound();
            }
            return View(композиции);
        }
        [Authorize]

        // POST: Композиции/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public ActionResult DeleteConfirmed(Guid id)
        {
            Композиции композиции = db.Композиции.Find(id);
            db.Композиции.Remove(композиции);
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
