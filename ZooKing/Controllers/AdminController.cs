using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooKing.DAL;
using ZooKing.Models;

namespace ZooKing.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private ZooKingContext db = new ZooKingContext();

        public AdminController()
        {
            
        }
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return Content("Hello Admin") ;
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }


	}
}