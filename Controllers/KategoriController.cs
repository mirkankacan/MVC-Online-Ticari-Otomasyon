﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        public ActionResult KategoriEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
             
                c.Kategoris.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
 
        }
        public ActionResult KategoriSil(int id)
        {
            var sil = c.Kategoris.Find(id);
            c.Kategoris.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var bul = c.Kategoris.Find(id);
            return View("KategoriGetir", bul);
        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var guncel = c.Kategoris.Find(k.KategoriID);
            guncel.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}