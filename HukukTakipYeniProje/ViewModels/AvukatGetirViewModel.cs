using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HukukTakipYeniProje.ViewModels
{
    public class AvukatGetirViewModel
    {

        public Guid AVUKATID { get; set; }
        public string MUSTERINO { get; set; }

        public string AVUKATAD { get; set; }
        public string AVUKATSOYAD { get; set; }
        public string AVUKATCEPTELNO { get; set; } 
        public string AVUKATISTELNO { get; set; }
        public string AVUKATAVANSHESAPNO { get; set; }
        public string AVUKATTIPI { get; set; }
        public string AVUKATEMAIL { get; set; }
        public string AVUKATTAMADRES { get; set; }
        public string AVUKATTCKN { get; set; }

        public string AVUKATKULLANICIADI { get; set; }

        public Guid AVANSHESAPSUBEID { get; set; }

        public Guid AVUKATMUSTERIID { get; set; }

        public Guid SEHIRID { get; set; }

        public Guid ILCEID { get; set; }


        //public string SelectedAvukatAdSoyad { get; set; }
        public List<SelectListItem> Sehirler { get; set; }

        public List<SelectListItem> Ilceler { get; set; }

        public List<SelectListItem> Musteriler { get; set; }

        //public List<SelectListItem> KullanıcıAdları { get; set; }

        public List<SelectListItem> Subeler { get; set; }

        //public List<SelectListItem> Ihtarlar { get; set; }
        public Guid SelectedSehırId { get; set; }

        public Guid SelectedIlceId { get; set; }

        public Guid SelectedMusteriId { get; set; }

        //public Guid SelectedKullanıcıAdı { get; set; }

        public Guid SelectedSubeId { get; set; }

        //public Guid SelectedIhtarId { get; set; }


    }
}