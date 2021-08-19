using _1_Pastelaria.Presentation.Infra;
using _2_Pastelaria.Application;
using _2_Pastelaria.Application.Model;
using System.Web.Mvc;

namespace _1_Pastelaria.Presentation.Controllers
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
            return View("LoginPastelaria");
        }

        public ActionResult Post(UsuarioModel usuario)
        {
            var response = _usuarioApplication.Post(usuario);
            if (!response.IsSuccessStatusCode)
                return Error(response.Content.ReadAsStringAsync().Result);

            return Success();
        }
    }
}