using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HukukTakipYeniProje.ViewModels
{
    public class IhtarGetirViewModel
    {
            public Guid IHTARID { get; set; }
            public string IHTARYEVMIYENO { get; set; }
            public DateTime IHTARTARIHI { get; set; }
             public Guid SelectedBorcluId { get; set; }
             public Guid SelectedNoterId { get; set; }
              public int IHTARSURE { get; set; }
            public DateTime IHTARTEBLIGTARIHI { get; set; }
            public DateTime IHTARTEBLIGGIRISTARIHI { get; set; }
            public Guid IHTARBORCLU { get; set; }
            public Guid IHTARNOTERADI { get; set; }
            public decimal IHTARNAMENAKITTUTAR { get; set; }
            public decimal IHTARNAMEGAYRINAKITTUTAR { get; set; }
            public int IHTARNO { get; set; }

            //public string SelectedAvukatAdSoyad { get; set; }
            public List<SelectListItem> Borclular { get; set; }
            public List<SelectListItem> Noterlikler { get; set; }

            //public List<SelectListItem> Ihtarlar { get; set; }

        }
}