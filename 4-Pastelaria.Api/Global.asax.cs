using _4_Pastelaria.Api.App_Start;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Routing;

namespace _4_Pastelaria.Api
{
    public class WebApiApplication : WebApiConfig
    {
        private static readonly IDependencyResolver _depResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.Build());
        public WebApiApplication() : base(_depResolver)
        {

        }
    }
}
