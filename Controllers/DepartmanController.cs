﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
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

            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

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
            var guncel = c.Departmans.Find(d.Departmanid);
            guncel.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
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
            return View();
        }
    }
}