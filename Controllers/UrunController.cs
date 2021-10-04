using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
           

                List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.KategoriAd,
                                                   Value = x.KategoriID.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                return View();
         
          
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            if (ModelState.IsValid)
            {
                c.Uruns.Add(u);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.KategoriAd,
                                                   Value = x.KategoriID.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                return View("UrunEkle");
            }
        }
     
        public ActionResult UrunSil(int id)
        {
            var sil = c.Uruns.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var bul = c.Uruns.Find(id);
            return View("UrunGetir", bul);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            if (ModelState.IsValid)
            {
                var guncel = c.Uruns.Find(u.Urunid);
                guncel.Urunad = u.Urunad;
                guncel.Marka = u.Marka;
                guncel.Stok = u.Stok;
                guncel.AlisFiyat = u.AlisFiyat;
                guncel.SatisFiyat = u.SatisFiyat;
                guncel.UrunGorsel = u.UrunGorsel;
                guncel.Durum = u.Durum;
                guncel.Kategoriid = u.Kategoriid;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.KategoriAd,
                                                   Value = x.KategoriID.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                return View("UrunGetir");
            }
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}