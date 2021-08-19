using SimpleInjector;
using _2_Pastelaria.Application;

namespace Pastelaria.Presentation.App_Start
{
    public static class SimpleInjectorContainer
    {
        public static Container Build()
        {
            var container = new Container();

            container.Register<UsuarioApplication>();

            container.Verify();

            return container;
        }
    }
}