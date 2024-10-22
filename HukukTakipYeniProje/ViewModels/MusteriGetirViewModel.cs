using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HukukTakipYeniProje.ViewModels
{
    public class MusteriGetirViewModel
    {
            
        public Guid MUSTERIID { get; set; }
        public string MUSTERINO { get; set; }

        public string MUSTERIAD { get; set; }
        public string MUSTERISOYAD { get; set; }
        public string MUSTERITCKN { get; set; }
        public DateTime MUSTERIDOGUMTARIHI { get; set; }
        public string MUSTERIDOGUMYERI { get; set; }
        public string MUSTERICINSIYET { get; set; }
        public string MUSTERIMEDENIDURUM { get; set; }

        public string MUSTERIBABABAAD { get; set; }
        public string MUSTERIANNEAD { get; set; }

        public string MUSTERISEMT { get; set; }

        public Guid SEHIRID { get; set; }

        public Guid ILCEID { get; set; }

        public string MUSTERIBORCLUTIPI { get; set; }

        public Guid BORCLUTURU { get; set; }

        //public string SelectedAvukatAdSoyad { get; set; }
        public List<SelectListItem> Sehirler { get; set; }

        public List<SelectListItem> Ilceler { get; set; }

        public List<SelectListItem> BorcluTurleri { get; set; }

        //public List<SelectListItem> Ihtarlar { get; set; }
        public Guid SelectedSehırId { get; set; }

        public Guid SelectedIlceId { get; set; }

        public Guid SelectedBorcluTuruId { get; set; }

        //public Guid SelectedIhtarId { get; set; }


    }

}