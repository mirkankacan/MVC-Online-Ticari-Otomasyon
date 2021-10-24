using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]

    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (ModelState.IsValid)
            {
                c.Kategoris.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("KategoriEkle");
            }
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
            if (ModelState.IsValid)
            {
                var guncel = c.Kategoris.Find(k.KategoriID);
                guncel.KategoriAd = k.KategoriAd;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("KategoriGetir");
            }
        }
      
    }
}