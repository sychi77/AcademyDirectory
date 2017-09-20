using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Academy.Services;
using Academy.Services.Interfaces;
using System.Web.Http;

namespace Academy.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IStudentsService, StudentsService>();
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}