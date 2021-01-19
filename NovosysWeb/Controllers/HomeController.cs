using Novosys.Services;
using NovosysWeb.CoreResources;
using NovosysWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovosysWEB.Controllers
{
    public class HomeController : Controller
    {

        private ApiServices apiServices;
        public HomeController()
        {
            apiServices = new ApiServices();  
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        [HttpPost]
        public object Email(Email e)
        {

            try
            {

               var result = apiServices.SendEmail(CoreResources.UrlBase, CoreResources.Prefix, CoreResources.EmailController, "Add", e);


                //if (generals.SendEmailSMTP(formCollection))
                if (result == "success")
                {
                    TempData["message"] = "Correo Enviado";
                    ViewBag.message = TempData["message"];
                }
                else
                {
                    TempData["message"] = "Problema al enviar correo";
                    ViewBag.message = TempData["message"];
                }

            }
            catch (Exception)
            {
                return Json(new { ViewBag.message });
            }

            return Json(new { ViewBag.message });
        }


    }
}