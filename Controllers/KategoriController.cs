using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();

        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList ();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriGetir(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILER.Add (p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORILER.Find (id);
            return View("KategoriGetir",kategori);
        }
        
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var kategori = db.TBLKATEGORILER.Find(p1.KategoriId);
            kategori.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }


    }
}