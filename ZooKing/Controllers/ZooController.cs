﻿using System;
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
    public class ZooController : Controller
    {
        private ZooKingContext db = new ZooKingContext();

        // GET: /Zoo/
        public ActionResult Index()
        {
            return View(db.Zoos.ToList());
        }

        // GET: /Zoo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoo zoo = db.Zoos.Find(id);
            if (zoo == null)
            {
                return HttpNotFound();
            }
            return View(zoo);
        }

        // GET: /Zoo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Zoo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,ShortInfo,YearOfEstablishment,Addres")] Zoo zoo)
        {
            if (ModelState.IsValid)
            {
                db.Zoos.Add(zoo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zoo);
        }

        // GET: /Zoo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoo zoo = db.Zoos.Find(id);
            if (zoo == null)
            {
                return HttpNotFound();
            }
            return View(zoo);
        }

        // POST: /Zoo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,ShortInfo,YearOfEstablishment,Addres")] Zoo zoo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoo);
        }

        // GET: /Zoo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zoo zoo = db.Zoos.Find(id);
            if (zoo == null)
            {
                return HttpNotFound();
            }
            return View(zoo);
        }

        // POST: /Zoo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zoo zoo = db.Zoos.Find(id);
            db.Zoos.Remove(zoo);
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
