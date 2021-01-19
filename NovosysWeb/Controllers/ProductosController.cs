using Novosys.Services;
using NovosysWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovosysWEB.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View(Get());
        }



        public ApiServices apiServices;
        public Services services;
        public HomeController hc;


        public ProductosController()
        {
            apiServices = new ApiServices();
            services = new Services();
            hc = new HomeController();
        }



        public object Get()
        {
            object o;

            try
            {
                o = services.Get<Producto>("productos").ToList();
            }
            catch (Exception)
            {
                return null;
            }

            return o;
        }


  

        public ActionResult Detalle(int id)
        {
            var o = new Producto();

            try
            {
                o = services.Get<Producto>("productos", id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            return View(o);
        }


    }
}