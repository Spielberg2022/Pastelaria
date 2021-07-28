using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastelaria.Controllers
{
    public class TarefasController : Controller
    {
        // GET: Tarefas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaTarefas()
        {
            return View();
        }

        public ActionResult CriarTarefa()
        {
            return View();
        }
    }
}