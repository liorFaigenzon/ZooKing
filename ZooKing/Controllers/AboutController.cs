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
    public class AboutController : Controller
    {
        private ZooKingContext db = new ZooKingContext();

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
