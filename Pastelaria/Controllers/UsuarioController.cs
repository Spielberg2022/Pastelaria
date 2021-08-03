using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pastelaria.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View("");
        }

        public ActionResult CadastroUsuario()
        {
            return View("");
        }

        public ActionResult Get(string senha) {
            return RedirectToAction("CadastroUsuario");
        }

        public ActionResult CriarUsuario(string tipoUsuario, string email, string senha, string nome, string dataNascimento,
            string telefoneFixo, string telefoneCelular, string logradouro, string bairro, string cidade, string uf, string cep, string foto)
        {
            return RedirectToAction("CadastroUsuario");
        }
    }
}