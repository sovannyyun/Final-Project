using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using CST356_Sovanny_Yun_FinalProject.Repository;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using CST356_Sovanny_Yun_FinalProject.Services;
using CST356_Sovanny_Yun_FinalProject.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CST356_Sovanny_Yun_FinalProject.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<ITodoRepository, TodoRepository>(Lifestyle.Scoped);
            container.Register<IHobbyRepository, HobbyRepository>(Lifestyle.Scoped);
            container.Register<ITodoService, TodoService>(Lifestyle.Scoped);
            container.Register<IHobbyService, HobbyService>(Lifestyle.Scoped);
            container.Register<Entities1, Entities1>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}