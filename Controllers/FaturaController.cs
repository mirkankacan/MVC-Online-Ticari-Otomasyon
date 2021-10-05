using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            if(ModelState.IsValid)
            { 
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return View("FaturaEkle");
            }
       
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            if(ModelState.IsValid)
            {
                var guncel = c.Faturalars.Find(f.Faturaid);
                guncel.FaturaSeriNo = f.FaturaSeriNo;
                guncel.FaturaSıraNo = f.FaturaSıraNo;
                guncel.Saat = f.Saat;
                guncel.Tarih = f.Tarih;
                guncel.TeslimAlan = f.TeslimAlan;
                guncel.TeslimEden = f.TeslimEden;
                guncel.VergiDairesi = f.VergiDairesi;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("FaturaGetir");
            }
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk, int id)
        {
            if (ModelState.IsValid)
            {
                c.FaturaKalems.Add(fk);
                c.SaveChanges();
  
                return RedirectToAction("Index");
            }
            else
            {
                return View("YeniKalem");
            }
        }
    }
}