using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.ads = degerler.CariAd + " " + degerler.CariSoyad;
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alici==mail).ToList().OrderByDescending(t=>t.Tarih);
            var gelensayisi = c.Mesajlars.Count(y => y.Alici == mail).ToString();
            ViewBag.gelen = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(y => y.Gonderici == mail).ToString();
            ViewBag.giden = gidensayisi;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelensayisi = c.Mesajlars.Count(y => y.Alici == mail).ToString();
            ViewBag.gelen = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(y => y.Gonderici == mail).ToString();
            ViewBag.giden = gidensayisi;
            return View(mesajlar);
        }

          public ActionResult MesajDetay()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(y => y.Alici == mail).ToString();
            ViewBag.gelen = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(y => y.Gonderici == mail).ToString();
            ViewBag.giden = gidensayisi;
            return View();
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(y => y.Alici == mail).ToString();
            ViewBag.gelen = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(y => y.Gonderici == mail).ToString();
            ViewBag.giden = gidensayisi;

            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}