using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HukukTakipYeniProje.Models.Entity;
using HukukTakipYeniProje.ViewModels;

namespace MvcGoksuHukukTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbHukukTakipEntities db = new MvcDbHukukTakipEntities();
        public ActionResult Index()
        {
            var degerler = db.URUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.AVUKATLAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AVUKATAD + " " + i.AVUKATSOYAD,
                                                 Value = i.AVUKATID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(URUNLER p1)
        {
            db.URUNLER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(Guid id)
        {
            var urun = db.URUNLER.Find(id);
            db.URUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(Guid id)
        {
            List<SelectListItem> degerler = (from i in db.MUSTERILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD + " " + i.MUSTERISOYAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }).ToList();

            List<SelectListItem> degerler2 = (from i in db.AVUKATLAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AVUKATAD + " " + i.AVUKATSOYAD,
                                                 Value = i.AVUKATID.ToString()
                                             }).ToList();


            var urn = db.URUNLER.Find(id);
            UrunGetirViewModel model = new UrunGetirViewModel();
            model.URUNID = urn.URUNID;
            model.URUNAD = urn.URUNAD;
            model.URUNTAKIPMIKTAR = (decimal)urn.URUNTAKIPMIKTAR;
            model.URUNTAKIPTARIHI = (DateTime)urn.URUNTAKIPTARIHI;
            model.URUNTAKIPBIRIMKODU = urn.URUNTAKIPBIRIMKODU;
            model.URUNTAKIPMUDINO = urn.URUNTAKIPMUDINO;
            model.SelectedBorcluId = urn.MUSTERILER.MUSTERIID;
            model.SelectedAvukatId = urn.AVUKATLAR.AVUKATID;
            model.Borclular = degerler;
            model.Avukatlar = degerler2;
            return View("UrunGetir", model);
        }

        public ActionResult Guncelle(UrunGetirViewModel p1)
        {
            var urn = db.URUNLER.Find(p1.URUNID);
            urn.URUNBORCLUID = p1.SelectedBorcluId;
            urn.URUNAD = p1.URUNAD;
            urn.URUNTAKIPMIKTAR = p1.URUNTAKIPMIKTAR;
            urn.URUNTAKIPTARIHI = p1.URUNTAKIPTARIHI;
            urn.URUNTAKIPBIRIMKODU = p1.URUNTAKIPBIRIMKODU;
            urn.URUNTAKIPMUDINO = p1.URUNTAKIPMUDINO;
            urn.URUNAVUKATID = p1.SelectedAvukatId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}