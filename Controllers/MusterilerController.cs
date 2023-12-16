using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusterilerController : Controller
    {
        // GET: Musteriler
        MvcDbStokEntities1 db = new MvcDbStokEntities1 ();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERILER.ToList ();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(TBLMUSTERILER p1)
        {
            
            db.TBLMUSTERILER.Add (p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find (id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}