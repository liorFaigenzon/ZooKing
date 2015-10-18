using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZooKing.Models;
using ZooKing.DAL;

namespace ZooKing.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AreaController : Controller
    {
        private ZooKingContext db = new ZooKingContext();

        // GET: /Area/
        [AllowAnonymous]
        public ActionResult Index()
        {
            var areas = db.Areas.Include(a => a.Zoo);
            return View(areas.ToList());
        }

        // GET: /Area/
        [AllowAnonymous]
        public ActionResult AreaAndZoo(int? Id)
        {
            System.Diagnostics.Debug.Write(Id);
            //db.Areas.Where(x => x.ID == areaId)
            var query = from zoo in db.Zoos
                        join area in db.Areas.Where(x => x.ID == Id) on zoo.ID equals area.ZooID
                        select new ZooAreaViewModel
                        {AreaName = area.Name, AreaSize = area.Size, ZooName = zoo.Name, ZooShortInfo = zoo.ShortInfo};

            return View(query);
        }

        // GET: /Area/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: /Area/Create
        public ActionResult Create()
        {
            ViewBag.ZooID = new SelectList(db.Zoos, "ID", "Name");
            return View();
        }

        // POST: /Area/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Size,PictureFileHandler,ZooID")] Area area)
        {
            if (ModelState.IsValid)
            {
                if (area.PictureFileHandler != null)
                {
                    string pic = System.IO.Path.GetFileName(area.PictureFileHandler.FileName);
                    string pathPic = System.IO.Path.Combine(
                                           Server.MapPath("~/Upload"), pic);
                    area.PictureFileHandler.SaveAs(pathPic);
                    area.Picture = "../Upload/" + pic;
                }

                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ZooID = new SelectList(db.Zoos, "ID", "Name", area.ZooID);
            return View(area);
        }

        // GET: /Area/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZooID = new SelectList(db.Zoos, "ID", "Name", area.ZooID);
            return View(area);
        }

        // POST: /Area/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include= "ID,Name,Size,PictureFileHandler,ZooID")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;

                try
                {
                    // new picture saving
                    if (area.PictureFileHandler != null)
                    {
                        string pic = System.IO.Path.GetFileName(area.PictureFileHandler.FileName);
                        string pathPic = System.IO.Path.Combine(
                                               Server.MapPath("~/Upload"), pic);
                        area.PictureFileHandler.SaveAs(pathPic);
                        area.Picture = "../Upload/" + pic;
                    }
                }
                catch (Exception)
                {
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZooID = new SelectList(db.Zoos, "ID", "Name", area.ZooID);
            return View(area);
        }

        // GET: /Area/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: /Area/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
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
