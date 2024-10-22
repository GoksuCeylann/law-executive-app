using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HukukTakipYeniProje.ViewModels
{
    public class IcraGetirViewModel
    {
        public Guid ICRAID { get; set; }
        public string ICRAUYAPDOSYANO { get; set; }
        public string ESASYILNO { get; set; }
        public Guid AVUKATID { get; set; }
        public DateTime ICRATAKIPTARIHI { get; set; }
        public string ICRATAKIPTIPI { get; set; }
        public Guid MUDURLUKID { get; set; }
        public string ICRAMAHIYETKODU { get; set; }
        public string ICRAAVUKATTEVZINO { get; set; }
        public Guid URUNID { get; set; }
        public decimal ICRAMIKTAR { get; set; }

        public Guid SelectedAvukatId { get; set; }
        public string SelectedAvukatAdSoyad { get; set; }
        public List<SelectListItem> Avukatlar { get; set; }

        public List<SelectListItem> Mudurlukler { get; set; }

        public List<SelectListItem> Urunler { get; set; }

        //public List<SelectListItem> Ihtarlar { get; set; }
        public Guid SelectedUrunId { get; set; }

        public Guid SelectedMudurlukId { get; set; }

        //public Guid SelectedIhtarId { get; set; }

        public Guid ICRAIHTARID { get; set; }




    }
}