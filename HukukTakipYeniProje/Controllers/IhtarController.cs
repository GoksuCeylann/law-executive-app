using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HukukTakipYeniProje.Models.Entity;
using HukukTakipYeniProje.ViewModels;

namespace MvcGoksuHukukTakip.Controllers
{
    public class IhtarController : Controller
    {
        // GET: Ihtar
        MvcDbHukukTakipEntities db = new MvcDbHukukTakipEntities();
        public ActionResult Index()
        {
            var degerler = db.IHTARLAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniIhtar()
        {
            List<SelectListItem> degerler = (from i in db.MUSTERILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD + " " + i.MUSTERISOYAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniIhtar(IHTARLAR p1)
        {
            p1.IHTARID = new Guid();
            db.IHTARLAR.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(Guid id)
        {
            var ihtar = db.IHTARLAR.Find(id);
            db.IHTARLAR.Remove(ihtar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IhtarGetir(Guid id)
        {
            List<SelectListItem> degerler = (from i in db.MUSTERILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD + " " + i.MUSTERISOYAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }).ToList();

            List<SelectListItem> degerler2 = (from i in db.NOTERLIKLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.NOTERAD,
                                                 Value = i.NOTERID.ToString()
                                             }).ToList();

            var iht = db.IHTARLAR.Find(id);
            IhtarGetirViewModel model = new IhtarGetirViewModel();
            model.IHTARID = iht.IHTARID;
            model.IHTARYEVMIYENO = iht.IHTARYEVMIYENO;
            model.IHTARTARIHI = (DateTime)iht.IHTARTARIHI;
            model.IHTARSURE = (int)iht.IHTARSURE;
            model.IHTARTEBLIGTARIHI = (DateTime)iht.IHTARTEBLIGTARIHI;
            model.IHTARTEBLIGGIRISTARIHI = (DateTime)iht.IHTARTEBLIGGIRISTARIHI;
            model.IHTARNAMENAKITTUTAR = (decimal)iht.IHTARNAMENAKITTUTAR;
            model.IHTARNAMEGAYRINAKITTUTAR = (decimal)iht.IHTARNAMEGAYRINAKITTUTAR;
            model.IHTARNO = (int)iht.IHTARNO;
            model.SelectedBorcluId = iht.MUSTERILER.MUSTERIID;
            model.SelectedNoterId = iht.NOTERLIKLER.NOTERID;
            model.Borclular = degerler;
            model.Noterlikler = degerler2;

            return View("IhtarGetir", model);
        }

        public ActionResult Guncelle(IhtarGetirViewModel p1)
        {
            var iht = db.IHTARLAR.Find(p1.IHTARID);
            iht.IHTARBORCLU = p1.SelectedBorcluId;
            iht.IHTARNOTERADI = p1.SelectedNoterId;
            iht.IHTARYEVMIYENO = p1.IHTARYEVMIYENO;
            iht.IHTARTARIHI = p1.IHTARTARIHI;
            iht.IHTARSURE = p1.IHTARSURE;
            iht.IHTARTEBLIGTARIHI = p1.IHTARTEBLIGTARIHI;
            iht.IHTARTEBLIGGIRISTARIHI = p1.IHTARTEBLIGGIRISTARIHI;
            iht.IHTARNAMENAKITTUTAR = p1.IHTARNAMENAKITTUTAR;
            iht.IHTARNAMEGAYRINAKITTUTAR = p1.IHTARNAMEGAYRINAKITTUTAR;
            iht.IHTARNO = p1.IHTARNO;


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}