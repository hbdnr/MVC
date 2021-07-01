using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_projesi.Models.varlik;

namespace MVC_projesi.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        mvc_verisetiEntities db = new mvc_verisetiEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_urun.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YEniEkle()
        {
            List<SelectListItem> ktgrlr = (from i in db.tbl_kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();

            //karşı sayfaya değer gönderme
            ViewBag.dgr = ktgrlr;
            return View();
        }

        [HttpPost]
        public ActionResult YEniEkle(tbl_urun prmt1)
        {
            var ktgr = db.tbl_kategori.Where(m => m.KATEGORIID == prmt1.tbl_kategori.KATEGORIID).FirstOrDefault();
            prmt1.tbl_kategori = ktgr;
            db.tbl_urun.Add(prmt1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var urunid = db.tbl_urun.Find(id);
            db.tbl_urun.Remove(urunid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> ktgrlr = (from i in db.tbl_kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();

            //karşı sayfaya değer gönderme
            ViewBag.dgr = ktgrlr;
            var urun = db.tbl_urun.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(tbl_urun prmt1)
        {
            var urun = db.tbl_urun.Find(prmt1.URUNID);
            urun.URUNAD = prmt1.URUNAD;
            urun.MARKA = prmt1.MARKA;
            urun.STOK = prmt1.STOK;
            //urun.KATEGORİ = prmt1.KATEGORİ;
            var ktgr = db.tbl_kategori.Where(m => m.KATEGORIID == prmt1.tbl_kategori.KATEGORIID).FirstOrDefault();
            urun.KATEGORİ = ktgr.KATEGORIID;
            urun.FİYAT = prmt1.FİYAT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}