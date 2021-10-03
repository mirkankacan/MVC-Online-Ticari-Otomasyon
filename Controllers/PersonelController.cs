using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();

        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (ModelState.IsValid)
            { 
                c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
            else
            {
                List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmanAd,
                                                   Value = x.Departmanid.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;

                return View("PersonelEkle");
            }
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
             var bul = c.Personels.Find(id);
            return View("PersonelGetir", bul);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (ModelState.IsValid)
            {
                var guncel = c.Personels.Find(p.Personelid);
                guncel.PersonelAd = p.PersonelAd;
                guncel.PersonelSoyad = p.PersonelSoyad;
                guncel.PersonelGorsel = p.PersonelGorsel;
                guncel.Departmanid = p.Departmanid;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.DepartmanAd,
                                                   Value = x.Departmanid.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                return View("PersonelGetir");
            }
          
        }

        public ActionResult PersonelSil(int id)
        {
            var sil = c.Personels.Find(id);
            c.Personels.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}