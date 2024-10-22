using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HukukTakipYeniProje.Models.Entity;
using HukukTakipYeniProje.ViewModels;

namespace MvcGoksuHukukTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbHukukTakipEntities db = new MvcDbHukukTakipEntities();
        public ActionResult Index()
        {
            var degerler = db.MUSTERILER.Where(p => p.MUSTERIBORCLUTURUID.HasValue).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(MUSTERILER p1)
        {
            db.MUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(Guid id)
        {
            var musteri = db.MUSTERILER.Find(id);
            db.MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(Guid id)
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

            List<SelectListItem> degerler3 = (from i in db.BORCLUTURLERI.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.BORCLUTURU,
                                                  Value = i.BORCLUTURUID.ToString()
                                              }).ToList();


            var mus = db.MUSTERILER.Find(id);
            MusteriGetirViewModel model = new MusteriGetirViewModel();
            model.MUSTERIID = mus.MUSTERIID;
            model.MUSTERINO = mus.MUSTERINO;
            model.MUSTERIAD = mus.MUSTERIAD;
            model.MUSTERISOYAD = mus.MUSTERISOYAD;
            model.MUSTERITCKN = mus.MUSTERITCKN;
            model.MUSTERIDOGUMTARIHI = (DateTime)mus.MUSTERIDOGUMTARIHI;
            model.MUSTERIDOGUMYERI = mus.MUSTERIDOGUMYERI;
            model.MUSTERICINSIYET = mus.MUSTERICINSIYET;
            model.MUSTERIMEDENIDURUM = mus.MUSTERIMEDENIDURUM;
            model.MUSTERIBABABAAD = mus.MUSTERIBABABAAD;
            model.MUSTERIANNEAD = mus.MUSTERIANNEAD;
            model.MUSTERISEMT = mus.MUSTERISEMT;
            model.MUSTERIBORCLUTIPI = mus.MUSTERIBORCLUTIPI;
            model.SelectedSehırId = mus.SEHIRLER.SEHIRID;
            model.SelectedIlceId = mus.ILCELER.ILCEID;
            model.SelectedBorcluTuruId = mus.BORCLUTURLERI.BORCLUTURUID;
            //model.SelectedIhtarId = icr.IHTARLAR.IHTARID;
            //model.SelectedAvukatAdSoyad = mus.AVUKATLAR.AVUKATAD + icr.AVUKATLAR.AVUKATSOYAD;
            model.Sehirler = degerler;
            model.Ilceler = degerler2;
            model.BorcluTurleri = degerler3;
            //model.Ihtarlar = degerler4;
            return View("MusteriGetir", model);
        }

        public ActionResult Guncelle(MusteriGetirViewModel p1)
        {
            var mus = db.MUSTERILER.Find(p1.MUSTERIID);
            mus.MUSTERINO = p1.MUSTERINO;
            mus.MUSTERISEHIRID = p1.SelectedSehırId;
            mus.MUSTERIAD = p1.MUSTERIAD;
            mus.MUSTERISOYAD = p1.MUSTERISOYAD;
            mus.MUSTERIILCEID = p1.SelectedIlceId;
            mus.MUSTERIBORCLUTURUID = p1.SelectedBorcluTuruId;
            mus.MUSTERITCKN = p1.MUSTERITCKN;
            mus.MUSTERIDOGUMTARIHI = p1.MUSTERIDOGUMTARIHI;
            mus.MUSTERIDOGUMYERI = p1.MUSTERIDOGUMYERI;
            mus.MUSTERICINSIYET = p1.MUSTERICINSIYET;
            mus.MUSTERIMEDENIDURUM = p1.MUSTERIMEDENIDURUM;
            mus.MUSTERIBABABAAD = p1.MUSTERIBABABAAD;
            mus.MUSTERIANNEAD = p1.MUSTERIANNEAD;
            mus.MUSTERISEMT = p1.MUSTERISEMT;
            mus.MUSTERIBORCLUTIPI = p1.MUSTERIBORCLUTIPI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}