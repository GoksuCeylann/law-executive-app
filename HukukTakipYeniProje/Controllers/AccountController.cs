using HukukTakipYeniProje.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HukukTakipYeniProje.Models.Entity;

namespace HukukTakipMvc.Controllers
{
    public class AccountController : Controller
    {
        private MvcDbHukukTakipEntities db = new MvcDbHukukTakipEntities(); // Use your DbContext

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the credentials are valid
                var user = db.KULLANICILAR.FirstOrDefault(u => u.KULLANICIAD == model.KULLANICIADI && u.SIFRE == model.SIFRE);

                if (user != null)
                {
                    // Authentication successful, redirect to the desired page (e.g., Icra/Index)
                    return RedirectToAction("Index", "Icra");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt. Please check your KULLANICIADI and SIFRE.");
                }
            }

            // If we reach here, something went wrong, return to the login page with an error message
            return View(model);
        }
    }
}
