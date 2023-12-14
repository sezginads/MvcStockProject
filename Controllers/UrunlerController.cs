﻿using System;
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
    }
}