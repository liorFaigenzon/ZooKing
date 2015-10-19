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
    public class ContactUsController : Controller
    {
        private ZooKingContext db = new ZooKingContext();

        [AllowAnonymous]
        public PartialViewResult GetAgeAvg()
        {
            var animals = db.Animals.Include(a => a.Area);

            var avg = animals.Average(animal => animal.Age);

            return PartialView(avg);
        }

        public ActionResult avg()
        {
            int sum=0;
            var animals = db.Animals.ToList();
            foreach (var animal in animals)
            {
                sum += animal.Age;
            }
            sum = (sum / animals.Count);
            return Json(new { data = sum.ToString() }, JsonRequestBehavior.AllowGet);
        }  

        [AllowAnonymous]
        public PartialViewResult GetAnimals()
        {
            Animal[] animals = db.Animals.ToArray();

            return PartialView(animals);
        }

        // GET: /Animal/
        [AllowAnonymous]
        public ActionResult Index(int? age, string name, int? type)
        {
            var animals = db.Animals.Include(a => a.Area);

            if (age.HasValue)
            {
                animals = animals.Where(animal => animal.Age == age);
            }

            if (!String.IsNullOrEmpty(name))
            {
                animals = animals.Where(animal => animal.Name == name);
            }

            if (type.HasValue)
            {
                animals = animals.Where(animal => animal.Type == type.ToString());
            }

            return View(animals.ToList());
        }

        // GET: /Animal/
        [AllowAnonymous]
        public ActionResult GroupBy(int? type)
        {
            var animals = db.Animals.Include(a => a.Area);

            return View(animals);
        }

        [AllowAnonymous]
        public ActionResult AnimalInArea(int? Id)
        {
            var query = from area in db.Areas
                        join animal in db.Animals.Where(x => x.ID == Id) on area.ID equals animal.AreaID
                        select new AnimalAreaViewModel
                        { AreaName = area.Name, AreaSize = area.Size, AnimalAge = animal.Age, AnimalName = animal.Name, AnimalId = animal.ID };

            return View(query);
        }



        // GET: /Animal/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: /Animal/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Name");
            return View();
        }

        // POST: /Animal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Type,PictureFileHandler,AreaID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.PictureFileHandler != null)
                {
                    string pic = System.IO.Path.GetFileName(animal.PictureFileHandler.FileName);
                    string pathPic = System.IO.Path.Combine(
                                           Server.MapPath("~/Upload"), pic);
                    animal.PictureFileHandler.SaveAs(pathPic);
                    animal.Picture = "../Upload/" + pic;
                }


                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Name", animal.AreaID);
            return View(animal);
        }

        // GET: /Animal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Name", animal.AreaID);

            //
            //if (animal.PictureFileHandler != null)
            //{
            //    string pic = System.IO.Path.GetFileName(animal.PictureFileHandler.FileName);
            //    string pathPic = System.IO.Path.Combine(
            //                           Server.MapPath("~/Upload"), pic);
            //    animal.PictureFileHandler.SaveAs(pathPic);
            //    animal.Picture = "../Upload/" + pic;
            //}
            //

            return View(animal);
        }

        // POST: /Animal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Age,Type,Picture,AreaID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;

                try
                {
                    // To save the new picture
                    string pic = System.IO.Path.GetFileName(animal.PictureFileHandler.FileName);
                    string pathPic = System.IO.Path.Combine(
                                           Server.MapPath("~/Upload"), pic);
                    animal.PictureFileHandler.SaveAs(pathPic);
                    animal.Picture = "../Upload/" + pic;
                }
                catch (Exception)
                {
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "Name", animal.AreaID);
            return View(animal);
        }

        // GET: /Animal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: /Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
