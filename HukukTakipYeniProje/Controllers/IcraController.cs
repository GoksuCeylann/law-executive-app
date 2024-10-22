using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HukukTakipYeniProje.Models.Entity;
using HukukTakipYeniProje.ViewModels;

namespace MvcGoksuHukukTakip.Controllers
{
    public class IcraController : Controller
    {
        // GET: Icra
        MvcDbHukukTakipEntities db = new MvcDbHukukTakipEntities();
        public ActionResult Index()
        {
            var degerler = db.ICRALAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniIcra()
        {
            List<SelectListItem> degerler = (from i in db.AVUKATLAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AVUKATAD + " " + i.AVUKATSOYAD,
                                                 Value = i.AVUKATID.ToString()
                                             }).ToList();

            List<SelectListItem> degerler2 = (from i in db.MUDURLUKLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MUDURLUKAD,
                                                  Value = i.MUDURLUKID.ToString()
                                              }).ToList();

            List<SelectListItem> degerler3 = (from i in db.URUNLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.URUNAD,
                                                  Value = i.URUNID.ToString()
                                              }).ToList();

            IcraGetirViewModel model = new IcraGetirViewModel();
            model.Avukatlar = degerler;
            model.Mudurlukler = degerler2;
            model.Urunler = degerler3;

            return View(model);
        }

        [HttpPost]
        public ActionResult YeniIcra(IcraGetirViewModel p1)
        {
            if (ModelState.IsValid)
            {
                // Generate a new GUID for the new Icra
                Guid newIcraId = Guid.NewGuid();

                // Create a new ICRALAR instance and populate it with data from the view model
                ICRALAR newIcra = new ICRALAR
                {
                    ICRAID = newIcraId,
                    ICRAUYAPDOSYANO = p1.ICRAUYAPDOSYANO,
                    ESASYILNO = p1.ESASYILNO,
                    ICRATAKIPTARIHI = p1.ICRATAKIPTARIHI,
                    ICRATAKIPTIPI = p1.ICRATAKIPTIPI,
                    ICRAAVUKAT = p1.SelectedAvukatId,
                    ICRAMUDURLUK = p1.SelectedMudurlukId,
                    ICRAURUN = p1.SelectedUrunId,
                    ICRAMAHIYETKODU = p1.ICRAMAHIYETKODU,
                    ICRAAVUKATTEVZINO = p1.ICRAAVUKATTEVZINO,
                    ICRAMIKTAR = p1.ICRAMIKTAR,
                    ICRAIHTARID = Guid.NewGuid()

                // Add other properties
            };

                // Add the new Icra to the database context
                db.ICRALAR.Add(newIcra);
                db.SaveChanges();

                // After saving, you can redirect to a different action or page
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return the same view with validation errors
            return View(p1);
        }

        public ActionResult SIL(Guid id)
        {
            var icra = db.ICRALAR.Find(id);
            db.ICRALAR.Remove(icra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IcraGetir(Guid id)
        {
            List<SelectListItem> degerler = (from i in db.AVUKATLAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AVUKATAD + " " + i.AVUKATSOYAD,
                                                 Value = i.AVUKATID.ToString()
                                             }).ToList();

            List<SelectListItem> degerler2 = (from i in db.MUDURLUKLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MUDURLUKAD,
                                                  Value = i.MUDURLUKID.ToString()
                                              }).ToList();

            List<SelectListItem> degerler3 = (from i in db.URUNLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.URUNAD,
                                                  Value = i.URUNID.ToString()
                                              }).ToList();

            //List<SelectListItem> degerler4 = (from i in db.IHTARLAR.ToList()
            //                                  select new SelectListItem
            //                                  {
            //                                      Text = i.IHTARNO.ToString(),
            //                                      Value = i.IHTARID.ToString()
            //                                  }).ToList();



            var icr = db.ICRALAR.Find(id);
            IcraGetirViewModel model = new IcraGetirViewModel();
            model.ICRAID = icr.ICRAID;
            model.ICRAUYAPDOSYANO = icr.ICRAUYAPDOSYANO;
            model.ESASYILNO = icr.ESASYILNO;
            model.ICRAMIKTAR = icr.ICRAMIKTAR.Value;
            model.ICRATAKIPTIPI = icr.ICRATAKIPTIPI;
            model.SelectedAvukatId = icr.AVUKATLAR.AVUKATID;
            model.SelectedMudurlukId = icr.MUDURLUKLER.MUDURLUKID;
            model.SelectedUrunId = icr.URUNLER.URUNID;
            //model.SelectedIhtarId = icr.IHTARLAR.IHTARID;
            model.SelectedAvukatAdSoyad = icr.AVUKATLAR.AVUKATAD + icr.AVUKATLAR.AVUKATSOYAD;
            model.ICRAAVUKATTEVZINO = icr.ICRAAVUKATTEVZINO;
            model.ICRAMAHIYETKODU = icr.ICRAMAHIYETKODU;
            model.Avukatlar = degerler;
            model.Mudurlukler = degerler2;
            model.Urunler = degerler3;
            //model.Ihtarlar = degerler4;
            return View("IcraGetir", model);
        }

        [HttpPost]
        public ActionResult Guncelle(IcraGetirViewModel p1)
        {
            try
            {
                var icr = db.ICRALAR.Find(p1.ICRAID);
                icr.ICRAUYAPDOSYANO = p1.ICRAUYAPDOSYANO;
                icr.ESASYILNO = p1.ESASYILNO;
                icr.ICRAAVUKAT = p1.SelectedAvukatId;
                icr.ICRAMUDURLUK = p1.SelectedMudurlukId;
                icr.ICRAURUN = p1.SelectedUrunId;
                icr.ICRATAKIPTARIHI = p1.ICRATAKIPTARIHI;
                icr.ICRATAKIPTIPI = p1.ICRATAKIPTIPI;
                //icr.ICRAMUDURLUK = p1.ICRAMUDURLUK;
                icr.ICRAMAHIYETKODU = p1.ICRAMAHIYETKODU;
                icr.ICRAAVUKATTEVZINO = p1.ICRAAVUKATTEVZINO;
                //icr.ICRAURUN = p1.ICRAURUN;
                icr.ICRAMIKTAR = p1.ICRAMIKTAR;
                icr.ICRAIHTARID = Guid.Parse("144B1F34-663C-4851-97ED-164455EBB740");//p1.ICRAIHTARID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
         }
    }
}