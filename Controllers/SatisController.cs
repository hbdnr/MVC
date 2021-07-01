using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_projesi.Models.varlik;

namespace MVC_projesi.Controllers
{
    public class SatisController : Controller
    {

        mvc_verisetiEntities db = new mvc_verisetiEntities();

        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(tbl_satislar prmt1)
        {
            db.tbl_satislar.Add(prmt1);
            db.SaveChanges();
            return View("Index");
        }

    }
}