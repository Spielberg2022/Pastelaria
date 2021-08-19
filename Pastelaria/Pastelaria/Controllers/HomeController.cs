using _2_Pastelaria.Application;
using _2_Pastelaria.Application.Model;
using Pastelaria.Domain.Usuario.Dto;
using Pastelaria.Presentation.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastelaria.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UsuarioApplication _usuarioApplication;

        public HomeController(UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        public ActionResult Index()
        {
            var response = _usuarioApplication.Get();
            if (!response.IsSuccessStatusCode)
                return Error("falha");

            return View("LoginPastelaria", new UsuarioModel());
        }

        public ActionResult Post(UsuarioModel usuario)
        {
            var response = _usuarioApplication.Post(usuario);
            if (!response.IsSuccessStatusCode)
                return Error(response.Content.ReadAsStringAsync().Result);

            return Success();
        }

        

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Login()
        //{
        //    ViewBag.Message = "Entre no sistema:";

        //    return View();
        //}

        //public ActionResult LoginPastelaria()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Principal(UsuarioDto usuario)
        //{
        //    if (true)
        //    {
        //        return View("Principal");
        //    }
        //    else
        //    {
        //        return View("Login");
        //    }
        //}

        //public ActionResult Get()
        //{
        //    return View("Principal");

        //}
    }
}