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
        public ActionResult Index(string p)
        {
            
            var urunler = from x in c.Uruns select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.Urunad.Contains(p)); // Ürün ad içinde p değikenini ara
            }
            return View(urunler.ToList());
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
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);

            ViewBag.dgr1 = deger1.Urunid;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}