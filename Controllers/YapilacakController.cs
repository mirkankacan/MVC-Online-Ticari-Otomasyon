using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context c = new Context();
        // GET: Yapilacak
        public ActionResult Index()
        {
            var bul = c.ToDos.ToList();
    
            return View(bul);
        }
        [HttpGet]
        public ActionResult YapilacakEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YapilacakEkle(ToDo t)
        {
            if (ModelState.IsValid)
            {
                c.ToDos.Add(t);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("YapilacakEkle");
            }
        }
    }
}