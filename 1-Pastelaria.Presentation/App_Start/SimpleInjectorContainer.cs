using _2_Pastelaria.Application;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_Pastelaria.Presentation.App_Start
{
    public class SimpleInjectorContainer
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