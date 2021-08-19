using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_Pastelaria.Presentation.Controllers
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

        public ActionResult Get(string email, string senha)
        {



            return RedirectToAction("ListaTarefas");
        }

        public ActionResult GetCriarTarefa(string idUsuario, string descricao, string dataLimiteExecucao, string mensagem)
        {
            return RedirectToAction("CriarTarefa");
        }
    }
}