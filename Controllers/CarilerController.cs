using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler car)
        {

            c.Carilers.Add(car);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CariSil(int id)
        {
            var sil = c.Carilers.Find(id);
            c.Carilers.Remove(sil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var bul = c.Carilers.Find(id);
            return View("CariGetir", bul);
        }
        public ActionResult CariGuncelle(Cariler car)
        {
            var guncel = c.Carilers.Find(car.Cariid);
            guncel.CariAd = car.CariAd;
            guncel.CariSoyad = car.CariSoyad;
            guncel.CariSehir = car.CariSehir;
            guncel.CariMail = car.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
     
    }
}