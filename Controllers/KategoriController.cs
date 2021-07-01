using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_projesi.Models.varlik;
using PagedList;
using PagedList.Mvc;
namespace MVC_projesi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        mvc_verisetiEntities db = new mvc_verisetiEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.tbl_kategori.ToList();

            var degerler = db.tbl_kategori.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }


        //Sayfada hiçbir işlem yapılmazsa ayni sadece sayfa yüklenirse işlem yapmadan view (Index) i dönder....
       [HttpGet]
        public ActionResult YeniEkle()
        {
            return View();
        }

        //Herhangi bir button click vs olay olursa değişmiş halini dönder....
        [HttpPost]
        public ActionResult YeniEkle(tbl_kategori prmt1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniEkle");
            }
            else
            {
                db.tbl_kategori.Add(prmt1);
                db.SaveChanges();
                return View();

            }
        }

        public ActionResult Sil(int id)
        {
            var ktgid = db.tbl_kategori.Find(id);
                db.tbl_kategori.Remove(ktgid);
                db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var ktgrid = db.tbl_kategori.Find(id);
            return View("Guncelle", ktgrid);
        }

        public ActionResult GuncellemeIslemi(tbl_kategori prmt1)
        {
            var ktgr = db.tbl_kategori.Find(prmt1.KATEGORIID);
            ktgr.KATEGORIAD = prmt1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}