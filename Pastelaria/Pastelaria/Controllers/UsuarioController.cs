
using _2_Pastelaria.Application;
using _2_Pastelaria.Application.Model;
using Pastelaria.Presentation.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastelaria.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly UsuarioApplication _usuarioApplication;

        public UsuarioController(UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }
        
        public ActionResult Index()
        {
            var response = _usuarioApplication.Get();
            if (!response.IsSuccessStatusCode)
                return Error("Falha");

            return View("LoginPastelaria", new UsuarioModel());
        }

        public ActionResult CadastroUsuario()
        {
            return View("");
        }

        public ActionResult GetLogin( string nome, string senha) 
        {
            return RedirectToAction("CadastroUsuario");
        }

        public ActionResult CriarUsuario(string tipoUsuario, string email, string senha, string nome, string dataNascimento,
            string telefoneFixo, string telefoneCelular, string logradouro, string bairro, string cidade, string uf, string cep, string foto)
        {
            return RedirectToAction("CadastroUsuario");
        }
    }
}