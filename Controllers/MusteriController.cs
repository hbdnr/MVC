using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_projesi.Models.varlik;

namespace MVC_projesi.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri

        mvc_verisetiEntities db = new mvc_verisetiEntities();
        public ActionResult Index(string prmt)
        {
            var degerler = from d in db.tbl_musteri select d;

            if (!string.IsNullOrEmpty(prmt))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(prmt));
            }

            return View(degerler.ToList());

            //var degerler = db.tbl_musteri.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniEkle(tbl_musteri prmt1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniEkle");
            }
            db.tbl_musteri.Add(prmt1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var musteriID = db.tbl_musteri.Find(id);
            db.tbl_musteri.Remove(musteriID);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BilgiGetir(int id)
        {
            var musteri = db.tbl_musteri.Find(id);
            return View("BilgiGetir", musteri);
        }

        public ActionResult Guncelle(tbl_musteri prmt1)
        {
            var must = db.tbl_musteri.Find(prmt1.MUSTERIID);
            must.MUSTERIAD = prmt1.MUSTERIAD;
            must.MUSTERISOYAD = prmt1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}