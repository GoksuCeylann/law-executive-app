using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HukukTakipYeniProje.ViewModels
{
    public class UrunGetirViewModel
    {
        public Guid URUNID { get; set; }
        public string URUNAD { get; set; }
        public decimal URUNTAKIPMIKTAR { get; set; }
        public DateTime URUNTAKIPTARIHI { get; set; }
        public string URUNTAKIPBIRIMKODU { get; set; }
        public string URUNTAKIPMUDINO { get; set; }
        public Guid BORCLUID { get; set; }
        public Guid AVUKATID { get; set; }

        //public string SelectedAvukatAdSoyad { get; set; }
        public List<SelectListItem> Borclular { get; set; }

        public List<SelectListItem> Avukatlar { get; set; }

        //public List<SelectListItem> Ihtarlar { get; set; }
        public Guid SelectedBorcluId { get; set; }

        public Guid SelectedAvukatId { get; set; }
    }
}