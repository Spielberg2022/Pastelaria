using _5_Pastelaria.Repository;
using _5_Pastelaria.Repository.Repositories;
using _6_Pastelaria.Services;
using _6_Pastelaria.Services.Services;
using Pastelaria.Domain.DisparoEmail;
using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Usuario;
using Pastelaria.Services.Services;
using ProjetoBanco.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace _4_Pastelaria.Api.App_Start
{
    public static class SimpleInjectorContainer
    {
        private static Container container;

        public static Container Build()
        {
            container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //Repositories
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<ITarefaRepository, TarefaRepository>();
            container.Register<IDisparoEmailRepository, DisparoEmailRepository>();

            //Services
            container.Register<ITarefaService, TarefaService>();
            container.Register<IDisparoEmailService, DisparoEmailService>();

            container.Register<Conexao>(Lifestyle.Scoped);

            container.Verify();

            return container;
        }

    }
}