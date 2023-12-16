using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler

        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList ();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle() 
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriId.ToString(),
                                             }).ToList();
            ViewBag.Degerler = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KategoriId == p1.TBLKATEGORILER.KategoriId).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges ();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        
    }
}