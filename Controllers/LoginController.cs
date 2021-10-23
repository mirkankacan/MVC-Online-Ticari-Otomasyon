using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(Admin x)
        { 
            if(ModelState.IsValid)
            {
                c.Admins.Add(x);
                c.SaveChanges();
                ViewBag.a = "Başarıyla kayıt oldunuz giriş yapınız";
                return View();

            }
            else
            {
               
                return View();
    }
    
        }
        [HttpGet]
        public ActionResult CariGir()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CariGir(Cariler ca)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == ca.CariMail && x.CariSifre == ca.CariSifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            { 
            return View();
            }
        }
        [HttpGet]
        public ActionResult AdminGir()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminGir(Admin a)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Cariler");
            }
            else
            {
                return View();
            }
        }
    }
}