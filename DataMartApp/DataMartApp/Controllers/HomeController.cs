using DataMartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DataMartApp.Controllers
{
    public class HomeController : Controller
    {
        developmentEntities db = new developmentEntities();
        private DbSet<seedData> seedDataList;

        // GET: Home
        public ActionResult Index()
        {
            seedDataList =  db.seedData;
            return View(seedDataList.ToList());
        }
    }
}