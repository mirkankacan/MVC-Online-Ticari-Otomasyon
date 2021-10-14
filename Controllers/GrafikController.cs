using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    
    public class GrafikController : Controller
    {
        Context c = new Context();
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(700, 700);
            grafikciz.AddTitle("Kategori ve Ürün Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Televizyon", "Ofis Eşyaları", "Küçük Ev Aleti" }, yValues: new[] { 500, 300, 610, 700 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public  ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.Urunad));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800).AddTitle("Stoklar").AddSeries(chartType: "Column", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1>Urunlistesi()
        {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunad = "Bilgisayar",
                stok = 120
            });
            snf.Add(new sinif1()
            {
                urunad = "Beyaz Eşya",
                stok = 150
            });
            return snf;
        }
    }
}