using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HukukTakipYeniProje.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string KULLANICIADI { get; set; }

        [Required]
        public string SIFRE { get; set; }
    }

}