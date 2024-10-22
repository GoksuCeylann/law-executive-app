using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HukukTakipYeniProje.Models.Entity;
using HukukTakipYeniProje.ViewModels;

namespace MvcGoksuHukukTakip.Controllers
{
    public class AvukatController : Controller
    {
        // GET: Avukat
        MvcDbHukukTakipEntities db = new MvcDbHukukTakipEntities();

        public ActionResult Index()
        {
            var degerler = db.AVUKATLAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniAvukat()
        {
            List<SelectListItem> degerler = (from i in db.SUBELER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SUBEAD,
                                                 Value = i.SUBEID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }



        [HttpPost]
        public ActionResult YeniAvukat(AVUKATLAR p1)
        {
            db.AVUKATLAR.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(Guid id)
        {
            var avukat = db.AVUKATLAR.Find(id);
            db.AVUKATLAR.Remove(avukat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AvukatGetir(Guid id)
        {
            List<SelectListItem> degerler = (from i in db.SEHIRLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SEHIRAD,
                                                 Value = i.SEHIRID.ToString()
                                             }).ToList();

            List<SelectListItem> degerler2 = (from i in db.ILCELER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.ILCEAD,
                                                  Value = i.ILCEID.ToString()
                                              }).ToList();

            List<SelectListItem> degerler3 = (from i in db.MUSTERILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MUSTERIAD + " " + i.MUSTERISOYAD,
                                                  Value = i.MUSTERIID.ToString()
                                              }).ToList();

            List<SelectListItem> degerler4 = (from i in db.SUBELER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.SUBEAD,
                                                  Value = i.SUBEID.ToString()
                                              }).ToList();


            var av = db.AVUKATLAR.Find(id);
            AvukatGetirViewModel model = new AvukatGetirViewModel();
            model.AVUKATID = av.AVUKATID;
            model.AVUKATAD = av.AVUKATAD;
            model.AVUKATSOYAD = av.AVUKATSOYAD;
            //model.AVUKATKULLANICIADIID = av.AVUKATKULLANICIADIID;
            model.AVUKATCEPTELNO = av.AVUKATCEPTELNO;
            model.AVUKATISTELNO = av.AVUKATISTELNO;
            model.AVUKATAVANSHESAPNO = av.AVUKATAVANSHESAPNO;
            model.AVUKATTIPI = av.AVUKATTIPI;
            model.AVUKATEMAIL = av.AVUKATEMAIL;
            model.AVUKATTAMADRES = av.AVUKATTAMADRES;
            model.AVUKATTCKN = av.AVUKATTCKN;
            model.SelectedSehırId = av.SEHIRLER.SEHIRID;
            model.SelectedIlceId = av.ILCELER.ILCEID;
            model.SelectedSubeId = av.SUBELER.SUBEID;
            model.SelectedMusteriId = av.MUSTERILER.MUSTERIID;
            model.Sehirler = degerler;
            model.Ilceler = degerler2;
            model.Musteriler = degerler3;
            model.Subeler = degerler4;
            return View("AvukatGetir", model);
        }

        public ActionResult Guncelle(AvukatGetirViewModel p1)
        {
            var av = db.AVUKATLAR.Find(p1.AVUKATID);
            av.AVUKATAD = p1.AVUKATAD;
            av.AVUKATSOYAD = p1.AVUKATSOYAD;
            av.AVUKATSEHIRID = p1.SelectedSehırId;
            av.AVUKATILCEID = p1.SelectedIlceId;
            av.AVUKATAVANSHESAPSUBEID = p1.SelectedSubeId;
            av.AVUKATMUSTERIID = p1.SelectedMusteriId;
            av.KULLANICILAR.KULLANICIAD = p1.AVUKATKULLANICIADI;
            av.AVUKATCEPTELNO = p1.AVUKATCEPTELNO;
            av.AVUKATISTELNO = p1.AVUKATISTELNO;
            av.AVUKATAVANSHESAPNO = p1.AVUKATAVANSHESAPNO;
            av.AVUKATTIPI = p1.AVUKATTIPI;
            av.AVUKATMUSTERIID = p1.AVUKATMUSTERIID;
            av.AVUKATEMAIL = p1.AVUKATEMAIL;
            av.AVUKATTAMADRES = p1.AVUKATTAMADRES;
            av.AVUKATTCKN = p1.AVUKATTCKN;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}