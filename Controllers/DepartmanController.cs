using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            if (ModelState.IsValid)
            {
                c.Departmans.Add(d);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("DepartmanEkle");
            }
        }
        public ActionResult DepartmanSil(int id)
        {
            var sil = c.Departmans.Find(id);
            sil.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var bul = c.Departmans.Find(id);
            return View("DepartmanGetir", bul);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            if (ModelState.IsValid)
            {
                var guncel = c.Departmans.Find(d.Departmanid);
                guncel.DepartmanAd = d.DepartmanAd;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("DepartmanGetir");
            }
        }
        public ActionResult DepartmanDetay(int id)
        {
            var bul = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x => x.Departmanid == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.depad = dpt;
            return View(bul);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var dpers = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd).FirstOrDefault();
            ViewBag.dpers = dpers;
            return View(degerler);
        }
    }
}