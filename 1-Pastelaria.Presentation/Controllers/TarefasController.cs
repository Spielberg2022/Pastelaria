using _1_Pastelaria.Presentation.Infra;
using _2_Pastelaria.Application.Model;
using _2_Pastelaria.Application.Tarefa;
using _2_Pastelaria.Application.Tarefa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _1_Pastelaria.Presentation.Controllers
{
    public class TarefasController : BaseController
    {
        private readonly TarefaApplication _tarefaApplication;

        public TarefasController(TarefaApplication tarefaApplication)
        {
            _tarefaApplication = tarefaApplication;
        }
        
        public ActionResult Index()
        {
            //var usuarioLogado = (UsuarioModel)Session["Usuario"];
            //var response = _tarefaApplication.Get(usuarioLogado.Id);
            //if (!response.IsSuccessStatusCode)
            //    return Error("Falha");

            return View("Index");
        }

        public ActionResult GetAll()
        {
            var usuarioLogado = (UsuarioModel)Session["Usuario"];
           

            if(usuarioLogado.CodigoTipoUsuario == 1)
            {
                var response = _tarefaApplication.GetPorIdGestor(usuarioLogado.Id);
                if (!response.IsSuccessStatusCode)
                    return Error("Falha");
                return View("_GridGestor", response.Content.ReadAsAsync<IEnumerable<TarefaModel>>().Result);
            } 
            else
            {
                var response = _tarefaApplication.Get(usuarioLogado.Id);
                if (!response.IsSuccessStatusCode)
                    return Error("Falha");
                return View("_Grid", response.Content.ReadAsAsync<IEnumerable<TarefaModel>>().Result);
            }
                
        }

        public ActionResult Post()
        {
            return View();
        }

        public ActionResult Get()
        {
            return View("ListaTarefas");
        }

        public ActionResult GetCriarTarefa(string idUsuario, string descricao, string dataLimiteExecucao, string mensagem)
        {
            return RedirectToAction("CriarTarefa");
        }
    }
}