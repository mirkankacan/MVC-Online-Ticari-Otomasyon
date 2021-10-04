using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urunad,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger3 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            List<SelectListItem> deger2 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            if (ModelState.IsValid)
            {
                s.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                c.SatisHarekets.Add(s);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Urunad,
                                                   Value = x.Urunid.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CariAd + " " + x.CariSoyad,
                                                   Value = x.Cariid.ToString()
                                               }).ToList();
                ViewBag.dgr2 = deger2;
                List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                   Value = x.Personelid.ToString()
                                               }).ToList();
                ViewBag.dgr3 = deger3;
                return View("SatisEkle");
            }

        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Urunad,
                                               Value = x.Urunid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger3 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            List<SelectListItem> deger2 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            var bul = c.SatisHarekets.Find(id);
            return View("SatisGetir", bul);
        }
        public ActionResult SatisGuncelle(SatisHareket p)
        {
            if (ModelState.IsValid)
            {
                var guncel = c.SatisHarekets.Find(p.Satisid);
                guncel.Urunid = p.Urunid;
                guncel.Personelid = p.Personelid;
                guncel.Cariid = p.Cariid;
                guncel.Fiyat = p.Fiyat;
                guncel.Adet = p.Adet;
                guncel.ToplamTutar = p.ToplamTutar;
                guncel.Tarih = p.Tarih;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Urunad,
                                                   Value = x.Urunid.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CariAd + " " + x.CariSoyad,
                                                   Value = x.Cariid.ToString()
                                               }).ToList();
                ViewBag.dgr2 = deger2;
                List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                   Value = x.Personelid.ToString()
                                               }).ToList();
                ViewBag.dgr3 = deger3;
                return View("SatisGetir");

            }
       
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(degerler);
        }
    }
}